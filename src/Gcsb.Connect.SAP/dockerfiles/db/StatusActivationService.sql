-- "JsdnBill"."StatusActivationService" definition

-- Drop table

-- DROP TABLE "JsdnBill"."StatusActivationService";
-- DROP SCHEMA "JsdnBill";

CREATE SCHEMA IF NOT EXISTS "JsdnBill" AUTHORIZATION postgres;


CREATE TABLE IF NOT EXISTS "JsdnBill"."StatusActivationService" (
	"Id" uuid NOT NULL,
	"OrderNumber" uuid NOT NULL,
	"CustomerCode" text NOT NULL,
	"ServiceCode" text NOT NULL,
	"OfferCode" text NOT NULL,
	"PurchaseDate" timestamp NOT NULL,
	"ActivationStatus" varchar NOT NULL,
	"ActivationDate" timestamp NULL,
	CONSTRAINT "PK_StatusActivationService" PRIMARY KEY ("Id")
);

INSERT INTO "JsdnBill"."StatusActivationService" ("Id", "OrderNumber", "CustomerCode", "ServiceCode", "OfferCode", "PurchaseDate", "ActivationStatus", "ActivationDate") VALUES('0bc97e91-45e9-438b-8529-a9cc24afc158'::uuid, '17f84fd0-bccc-4502-9193-c4f72ae55738'::uuid, '4016949', 'docdrivepremium2tb', 'DOCDRIVE Premium 2 TB', '2022-08-24 00:00:00.000', 'ServiceActivated', '2022-08-24 00:00:00.000');
