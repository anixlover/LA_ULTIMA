﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAO;


namespace CTR
{
    public class CtrMXUEstado
    {
        DaoMXUEstado objDaoMXUEstado;
        public CtrMXUEstado()
        {
            objDaoMXUEstado = new DaoMXUEstado();
        }
        public DataSet ListarEstados(string estado)
        {
            try
            {
                var estadosSeleccionados = workflowEstados.First(x => x.Key == estado).Value;

                if (estadosSeleccionados == null) throw new Exception("No se pudo obtener los estados para el estado { estado }" );

                var estadosParaEnviar = estadosSeleccionados.Select(x => x.ToString()).Aggregate((x, y) => x + "," + y);

                var estados = objDaoMXUEstado.SelectMXUEstado(estadosParaEnviar);

                return estados;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }


        private Dictionary<string, IEnumerable<int>> workflowEstados = new Dictionary<string, IEnumerable<int>>()
        {
            { "fabricacion", new List<int>() { 7, 8 } },
            { "retrazo fabricacion", new List<int>() { 8 } },
            { "secado", new List<int>() { 9, 10  } },
            { "retraso secado", new List<int>() { 10 } },
            { "empaquetado", new List<int>() { 11 } }
        };
    }
}
