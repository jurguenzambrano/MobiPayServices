using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace UsuariosTest
{
    [TestClass]
    public class MonederosTest
    {
        [TestMethod]
        public void RecargarOk()
        {
            MonederoService.MonederosServiceClient proxy = new MonederoService.MonederosServiceClient();
            MonederoService.RecargaBE recarga = new MonederoService.RecargaBE()
            {
                CodigoCliente = "Ba2217an",
                Monto = 10,
                OperacionBanco = "R",
            };

            MonederoService.MovimientoBE movimiento = proxy.Recargar(recarga);

            Assert.AreEqual("Ba2217an", movimiento.CodigoCliente);
            Assert.AreEqual(10, movimiento.Monto);
            Assert.AreEqual("R", movimiento.OperacionBanco);


        }

        [TestMethod]
        public void RecargarErrorNoEncontradoCliente()
        {
            try
            {
                MonederoService.MonederosServiceClient proxy = new MonederoService.MonederosServiceClient();
                MonederoService.MovimientoBE movimiento = new MonederoService.MovimientoBE()
                {
                    CodigoCliente = "codigonoexiste",
                    Monto = 10,
                    OperacionBanco = "R",
                };
            }
            catch (Exception e)
            {
                Assert.AreEqual("Error al buscar cliente", e.Message);
            }
        }

        [TestMethod]
        public void RecargarErrorMontoMaximoSuperado()
        {
            try
            {
                MonederoService.MonederosServiceClient proxy = new MonederoService.MonederosServiceClient();
                MonederoService.MovimientoBE movimiento = new MonederoService.MovimientoBE()
                {
                    CodigoCliente = "011016000001",
                    Monto = 1000000000,
                    OperacionBanco = "R",
                };
            }
            catch (Exception e)
            {
                Assert.AreEqual("Monto máximo de recarga superado", e.Message);
            }
        }

        [TestMethod]
        public void ExtornarOk()
        {
            MonederoService.MonederosServiceClient proxy = new MonederoService.MonederosServiceClient();
            MonederoService.ExtornoBE extorno = new MonederoService.ExtornoBE()
            {
                CodigoCliente = "Ba2217an",
                Monto = 10,
                OperacionBanco = "RExterno",
                OperacionBancoExtorno = "R"
            };

            MonederoService.MovimientoBE movimiento = proxy.Extornar(extorno);

            Assert.AreEqual("Ba2217an", movimiento.CodigoCliente);
            Assert.AreEqual(-10.00M, movimiento.Monto);
            Assert.AreEqual("RExterno", movimiento.OperacionBanco);
        }
    }


}
