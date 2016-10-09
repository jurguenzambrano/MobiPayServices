﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DSD.BusinessEntity;
using DSD.DataAccess;
using DSD.Exceptions;

namespace DSD.WCF.Services
{
    public class MonederosService : IMonederosService
    {
        private MovimientosDA movimientoDA = new MovimientosDA();
        private UsuariosDA usuarioDA = new UsuariosDA();
        private UsuarioBE usuarioBE = null;

        public MovimientoBE Recargar(RecargaBE recarga)
        {
            usuarioBE = usuarioDA.ObtenerPorCodigoCliente(recarga.CodigoCliente);
            if (usuarioBE == null)
            {
                throw new FaultException<MessageException>(
                    new MessageException()
                    {
                        Codigo = "101",
                        Descripcion = "El código de cliente no existe"
                    }, new FaultReason("Error al buscar cliente")
                );
            }
            if(usuarioBE.MontoMaximo < recarga.Monto)
            {
                throw new FaultException<MessageException>(
                    new MessageException()
                    {
                        Codigo = "102",
                        Descripcion = "El monto a recargar es mayor al monto máximo de recarga del cliente"
                    }, new FaultReason("Monto máximo de recarga superado")
                );
            }

            MovimientoBE movimiento = new MovimientoBE();
            movimiento.CodigoCliente = recarga.CodigoCliente;
            movimiento.OperacionBanco = recarga.OperacionBanco;
            movimiento.Tipo = "R";
            movimiento.Monto = recarga.Monto;
            return movimientoDA.Crear(movimiento);
        }

        public MovimientoBE Extornar(ExtornoBE extorno)
        {
            MovimientoBE movimientoBE = movimientoDA.ObtenerPorClienteOperacion(extorno.CodigoCliente, extorno.OperacionBanco);
            if (movimientoBE == null)
            {
                throw new FaultException<MessageException>(
                    new MessageException()
                    {
                        Codigo = "103",
                        Descripcion = "El código de cliente o número de operación no coinciden"
                    }, new FaultReason("Número de operación no encontrada")
                );
            }

            if (movimientoBE.Monto != extorno.Monto)
            {
                throw new FaultException<MessageException>(
                    new MessageException()
                    {
                        Codigo = "104",
                        Descripcion = "El monto a extornar no coincide con la operación"
                    }, new FaultReason("Monto a extornar no válido")
                );
            }

            MovimientoBE movimiento = new MovimientoBE();
            movimiento.CodigoCliente = extorno.CodigoCliente;
            movimiento.OperacionBanco = extorno.OperacionBanco;
            movimiento.Tipo = "E";
            movimiento.Monto = extorno.Monto * -1;
            return movimientoDA.Crear(movimiento);
        }

        public MovimientoBE Pagar(PagoBE pago)
        {
            usuarioBE = usuarioDA.ObtenerPorCodigoCliente(pago.CodigoCliente);
            if (usuarioBE == null)
            {
                throw new FaultException<MessageException>(
                    new MessageException()
                    {
                        Codigo = "101",
                        Descripcion = "El código de cliente no existe"
                    }, new FaultReason("Error al buscar cliente")
                );
            }
            if (usuarioBE.Saldo < pago.Monto)
            {
                throw new FaultException<MessageException>(
                    new MessageException()
                    {
                        Codigo = "105",
                        Descripcion = "El monto a pagar es mayor al saldo del cliente"
                    }, new FaultReason("No cuenta con saldo suficiente")
                );
            }

            MovimientoBE movimiento = new MovimientoBE();
            movimiento.CodigoCliente = pago.CodigoCliente;
            movimiento.OperacionBanco = pago.OperacionBanco;
            movimiento.Tipo = "R";
            movimiento.Monto = pago.Monto;
            return movimientoDA.Crear(movimiento);
        }

        public MovimientoBE Saldo(SaldoBE saldo)
        {
            throw new NotImplementedException();
        }
    }
}