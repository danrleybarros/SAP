-- DROP SCHEMA "DigitalCertificate";

CREATE SCHEMA "DigitalCertificate" AUTHORIZATION postgres;

-- DROP TABLE "DigitalCertificate"."Order";

CREATE TABLE "DigitalCertificate"."Order" (
	"Id" uuid NOT NULL,
	"OrderNumber" text NOT NULL,
	"OrderDate" timestamp NOT NULL,
	"OrderExpirationDate" timestamp NOT NULL,
	"CustomerCode" text NOT NULL,
	"Cnpj" text NOT NULL,
	"CompanyName" text NOT NULL,
	"StoreAcronym" text NOT NULL,
	CONSTRAINT "Order_pk" PRIMARY KEY ("Id")
);


-- "DigitalCertificate"."Parameter" definition

-- Drop table

-- DROP TABLE "DigitalCertificate"."Parameter";

CREATE TABLE "DigitalCertificate"."Parameter" (
	"Id" uuid NOT NULL,
	"EmailExpirationDay" int4 NOT NULL,
	"PeriodicityHour" int4 NOT NULL,
	"OrderExpirationDay" int4 NOT NULL,
	CONSTRAINT "Parameter_pk" PRIMARY KEY ("Id")
);


-- "DigitalCertificate"."Template" definition

-- Drop table

-- DROP TABLE "DigitalCertificate"."Template";

CREATE TABLE "DigitalCertificate"."Template" (
	"Id" uuid NOT NULL,
	"ISV" text NOT NULL,
	"Name" text NOT NULL,
	"Subject" text NOT NULL,
	"From" text NOT NULL,
	"Message" text NOT NULL,
	"Status" bool NOT NULL,
	CONSTRAINT "Template_pk" PRIMARY KEY ("Id")
);


-- "DigitalCertificate"."User" definition

-- Drop table

-- DROP TABLE "DigitalCertificate"."User";

CREATE TABLE "DigitalCertificate"."User" (
	"UserId" int8 NOT NULL,
	"FisrtName" text NOT NULL,
	"LastName" text NOT NULL,
	"Email" text NOT NULL,
	"CompanyAcronym" text NOT NULL,
	"CPF" text NOT NULL,
	CONSTRAINT "User_pk" PRIMARY KEY ("UserId")
);


-- "DigitalCertificate"."EventLog" definition

-- Drop table

-- DROP TABLE "DigitalCertificate"."EventLog";

CREATE TABLE "DigitalCertificate"."EventLog" (
	"Id" uuid NOT NULL,
	"Event" text NOT NULL,
	"EventDate" timestamp NOT NULL,
	"EventRequest" jsonb NULL,
	"EventResponse" jsonb NULL,
	"Status" bool NOT NULL,
	"UserId" int8 NOT NULL,
	CONSTRAINT "EventLog_pk" PRIMARY KEY ("Id"),
	CONSTRAINT "EventLog_fk_UserId" FOREIGN KEY ("UserId") REFERENCES "DigitalCertificate"."User"("UserId")
);


-- "DigitalCertificate"."Offer" definition

-- Drop table

-- DROP TABLE "DigitalCertificate"."Offer";

CREATE TABLE "DigitalCertificate"."Offer" (
	"Id" uuid NOT NULL,
	"OfferCode" text NOT NULL,
	"OfferName" text NOT NULL,
	"LicenseNum" int4 NOT NULL,
  	"ServiceCode" text NOT NULL,  
	"OrderId" uuid NOT NULL,
	"LicenseStatus" bool NOT NULL DEFAULT TRUE,	
	CONSTRAINT "Offer_pk" PRIMARY KEY ("Id"),
	CONSTRAINT "Offer_fk_OrderId" FOREIGN KEY ("OrderId") REFERENCES "DigitalCertificate"."Order"("Id")
);


-- "DigitalCertificate"."Certificate" definition

-- Drop table

-- DROP TABLE "DigitalCertificate"."Certificate";

CREATE TABLE "DigitalCertificate"."Certificate" (
	"Id" uuid NOT NULL,
	"ProtocolNumber" text NOT NULL,
	"ProtocolStatus" text NOT NULL,
	"IssueDate" timestamp NOT NULL,
	"ActivationDate" timestamp NULL,
	"ExpirationDate" timestamp NULL,
	"AssignStatus" bool NOT NULL,
	"CertificateStatus" text NOT NULL,
	"UserId" int8 NOT NULL,
	"OfferId" uuid NOT NULL,
	CONSTRAINT "Certificate_pk" PRIMARY KEY ("Id"),
	CONSTRAINT "Certificate_fk_Id" FOREIGN KEY ("OfferId") REFERENCES "DigitalCertificate"."Offer"("Id"),
	CONSTRAINT "Certificate_fk_UserId" FOREIGN KEY ("UserId") REFERENCES "DigitalCertificate"."User"("UserId")
);

-- DROP TABLE "DigitalCertificate"."History";

CREATE TABLE "DigitalCertificate"."History" (
	"Id" uuid NOT NULL,	
	"CertificateStatus" text NOT NULL,
	"LastUpdateDate" timestamp NOT NULL,
	"CertificateId" uuid NOT NULL,
	CONSTRAINT "History_pk" PRIMARY KEY ("Id"),
	CONSTRAINT "History_fk_CertificateId" FOREIGN KEY ("CertificateId") REFERENCES "DigitalCertificate"."Certificate"("Id")
);

-- "DigitalCertificate".vw_certificate_status_license source

CREATE OR REPLACE VIEW "DigitalCertificate".vw_certificate_status_license
AS WITH license AS (
         SELECT row_number() OVER () AS row_number,
            f."OfferCode",
            f."ServiceCode",
            o."OrderNumber",
            o."OrderDate",
                CASE
                    WHEN c."CertificateStatus" = 'Aguardando Emissão'::text OR c."CertificateStatus" = 'Aguardando Requisição'::text OR c."CertificateStatus" = 'Aguardando Validação'::text OR c."CertificateStatus" = 'Aguardando Verificaçao'::text THEN 'Não Emitido'::text
                    WHEN c."CertificateStatus" = 'Revogado'::text THEN ' Emitido-Cancelado'::text
                    WHEN c."CertificateStatus" = 'Cancelado'::text THEN 'Não Emitido-Cancelado'::text
                    WHEN c."CertificateStatus" = 'Expirado'::text THEN 'Expirado'::text
                    ELSE c."CertificateStatus"
                END AS "Status"
           FROM "DigitalCertificate"."Certificate" c
             JOIN "DigitalCertificate"."Offer" f ON f."Id" = c."OfferId"
             JOIN "DigitalCertificate"."Order" o ON o."Id" = f."OrderId"
        UNION ALL
         SELECT generate_series(1::bigint, f."LicenseNum" - count(*)) AS row_number,
            f."OfferCode",
            f."ServiceCode",
            o."OrderNumber",
            o."OrderDate",
                CASE
                    WHEN f."LicenseStatus" = true THEN 'Não Emitido'::text
                    ELSE 'Não Emitido-Cancelado'::text
                END AS "Status"
           FROM "DigitalCertificate"."Certificate" c
             JOIN "DigitalCertificate"."Offer" f ON f."Id" = c."OfferId"
             JOIN "DigitalCertificate"."Order" o ON o."Id" = f."OrderId"
          GROUP BY f."LicenseNum", f."OfferCode", f."ServiceCode", o."OrderNumber", f."Id", o."OrderDate"
         HAVING count(*) < f."LicenseNum"
        )
 SELECT license."OfferCode",
    license."ServiceCode",
    license."OrderNumber",
    license."OrderDate",
    license."Status"
   FROM license;