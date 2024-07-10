using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.DigitalCertificate;
using Gcsb.Connect.SAP.Tests.Builders.DigitalCertificate;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class DigitalCertificateMock
    {
        public Mock<IDigitalCertificateRepository> Execute()
        {
            var mockCertificateStatusLicense = new Mock<IDigitalCertificateRepository>();

            mockCertificateStatusLicense
                .Setup(s => s.GetCerficateStatusLicense(It.IsAny<List<string>>()))
                .Returns(new List<CertificateStatusLicense>
                {
                      #region NotEmittedPaid
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("12345").WithLicenseNum(6).WithStatus("Aguardando Requisição").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("12345").WithLicenseNum(6).WithStatus("Aguardando Emissão").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("12345").WithLicenseNum(6).WithStatus("Aguardando validação").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("12345").WithLicenseNum(6).WithStatus("Aguardando verificação").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("12345").WithLicenseNum(6).WithStatus("Cancelado").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("12345").WithLicenseNum(6).WithStatus("Certificado não foi enviado ao ISV").Build(),
                      #endregion                                                   

                      #region NotEmittedNotPaid
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("23456").WithLicenseNum(2).WithStatus("Aguardando Requisição").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("23456").WithLicenseNum(2).WithStatus("Aguardando Emissão").Build(),
                      #endregion

                      #region #Emitted and Revoke
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("789456").WithLicenseNum(1).WithStatus("Emitido").Build(),
                      CertificateStatusLicenseBuilder.New().WithOrderNumber("456654").WithLicenseNum(1).WithStatus("Revogado").Build()
                      #endregion


                });

            return mockCertificateStatusLicense;
        }
    }
}
