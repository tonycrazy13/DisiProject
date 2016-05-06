using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DisiProject.Models;
using DisiProject.Models.PortalClientes;
using OfficeOpenXml;

//using OfficeOpenXml;
namespace DisiProject.Controllers.Listas
{
    public class ReportesController : Controller
    {
        readonly DisiContext _db = new DisiContext();
        //
        // GET: /Reportes/

        public ActionResult SaldosCrEditos()
        {
            return View();
        }
        public ActionResult DocumentosPorVencer()
        {
            var dpv = _db.Saldo.Where(p => p.fdMontoEstimadoTrim == 789);
            return View(dpv.ToList());
        }
        public ActionResult SaldosVencidos()
        {
            var dpv = _db.Saldo.Where(p => p.fdMontoEstimadoTrim == 456);
            return View(dpv.ToList());
        }
        [HttpPost]
        public ActionResult SaldosCrEditos(DataTable tb)
        {
            //var tblSaldo = _db.SaldoPorTipoCreditos;
            tb = new DataTable();
            tb.Columns.Add(new DataColumn("ID", typeof(string)));
            tb.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tb.Columns.Add(new DataColumn("MontoEstimadoTrim", typeof(string)));
            tb.Columns.Add(new DataColumn("MontoEstimadoAnual", typeof(string)));
            tb.Columns.Add(new DataColumn("Observacioens", typeof(string)));

            for (Int32 i = 1; i < _db.Saldo.Count(); i++)
            {
                DataRow row = tb.NewRow();
                Saldo sc = _db.Saldo.First(p => p.fiIdSaldoCredito == i);
                row["ID"] = sc.fiIdSaldoCredito.ToString();
                row["Descripcion"] = sc.fcDescripcion.ToString();
                row["MontoEstimadoTrim"] = sc.fdMontoEstimadoTrim.ToString();
                row["MontoEstimadoAnual"] = sc.fdMontoEstimadoAnual.ToString();
                row["Observacioens"] = sc.fcObservaciones.ToString();
                tb.Rows.Add(row);
            }
            ExportToExcel(tb);
            return View();
        }
        [HttpPost]
        public ActionResult DocumentosPorVencer(DisiContext dc)
        {
            //var tblSaldo = _db.SaldoPorTipoCreditos;
            DataTable tb = new DataTable();
            tb.Columns.Add(new DataColumn("ID", typeof(string)));
            tb.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tb.Columns.Add(new DataColumn("MontoEstimadoTrim", typeof(string)));
            tb.Columns.Add(new DataColumn("MontoEstimadoAnual", typeof(string)));
            tb.Columns.Add(new DataColumn("Observacioens", typeof(string)));

            for (Int32 i = 14; i < 21; i++)
            {
                DataRow row = tb.NewRow();
                Saldo sc = _db.Saldo.First(p => p.fiIdSaldoCredito == i);
                row["ID"] = sc.fiIdSaldoCredito.ToString();
                row["Descripcion"] = sc.fcDescripcion.ToString();
                row["MontoEstimadoTrim"] = sc.fdMontoEstimadoTrim.ToString();
                row["MontoEstimadoAnual"] = sc.fdMontoEstimadoAnual.ToString();
                row["Observacioens"] = sc.fcObservaciones.ToString();
                tb.Rows.Add(row);
            }
            ExportToExcel(tb);
            var dpv = _db.Saldo.Where(p => p.fdMontoEstimadoTrim == 789);
            return View(dpv.ToList());
        }
        [HttpPost]
        public ActionResult SaldosVencidos(DataTable tb)
        {
            //var tblSaldo = _db.SaldoPorTipoCreditos;
            tb = new DataTable();
            tb.Columns.Add(new DataColumn("ID", typeof(string)));
            tb.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tb.Columns.Add(new DataColumn("MontoEstimadoTrim", typeof(string)));
            tb.Columns.Add(new DataColumn("MontoEstimadoAnual", typeof(string)));
            tb.Columns.Add(new DataColumn("Observacioens", typeof(string)));

            for (Int32 i = 7; i < 14; i++)
            {
                DataRow row = tb.NewRow();
                Saldo sc = _db.Saldo.First(p => p.fiIdSaldoCredito == i);
                row["ID"] = sc.fiIdSaldoCredito.ToString();
                row["Descripcion"] = sc.fcDescripcion.ToString();
                row["MontoEstimadoTrim"] = sc.fdMontoEstimadoTrim.ToString();
                row["MontoEstimadoAnual"] = sc.fdMontoEstimadoAnual.ToString();
                row["Observacioens"] = sc.fcObservaciones.ToString();
                tb.Rows.Add(row);
            }
            ExportToExcel(tb);
            var dpv = _db.Saldo.Where(p => p.fdMontoEstimadoTrim == 456);
            return View(dpv.ToList());
        }
        public void ExportToExcel(DataTable tbl)
        {
            try
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    // Crear la Hoja
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("credito");

                    // columnas
                    for (int i = 0; i < tbl.Columns.Count; i++)
                    {
                        ws.Cells[1, (i + 1)].Value = tbl.Columns[i].ColumnName;
                    }

                    // rows
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        for (int j = 0; j < tbl.Columns.Count; j++)
                        {
                            ws.Cells[(i + 2), (j + 1)].Value = tbl.Rows[i][j];
                        }
                    }

                    // Escribir de nuevo al cliente
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=" + DateTime.Now + ".xlsx");
                    Response.BinaryWrite(pck.GetAsByteArray());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorExcel"] = "ErrorExcel: " + ex.ToString();
            }
        }
    }
}
