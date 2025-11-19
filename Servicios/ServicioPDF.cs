using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Xml.Linq;

namespace Servicios
{
    public class ServicioPDF
    {
        #region autorizacion
        public static string GenerarPDFAutorizacion(BEAutorizacion autorizacion)
        {
            try
            {
                string carpetaPDFs = Path.Combine(ServicioDirectorio.RutaPDFs, "Autorizaciones");

                if (!Directory.Exists(carpetaPDFs))
                    Directory.CreateDirectory(carpetaPDFs);

                string nombreArchivo = $"Autorizacion_{autorizacion.NumeroAutorizacion}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(carpetaPDFs, nombreArchivo);

                Document documento = new Document(PageSize.A4);
                PdfWriter.GetInstance(documento, new FileStream(rutaCompleta, FileMode.Create));

                documento.Open();

                AgregarEncabezado(documento);
                AgregarDatosAutorizacion(documento, autorizacion);
                AgregarPieDePagina(documento);

                documento.Close();

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar PDF de autorización: " + ex.Message);
            }
        }
        private static void AgregarEncabezado(Document documento)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
            Paragraph titulo = new Paragraph("AUTORIZACIÓN MÉDICA", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            documento.Add(titulo);

            documento.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));
            documento.Add(new Paragraph(" ")); 
        }
        private static void AgregarDatosAutorizacion(Document documento, BEAutorizacion autorizacion)
        {
            Font fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            Paragraph nroAutorizacion = new Paragraph();
            nroAutorizacion.Add(new Chunk("Nº de Autorización: ", fuenteNegrita));
            nroAutorizacion.Add(new Chunk(autorizacion.NumeroAutorizacion.ToString(),
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED)));
            nroAutorizacion.SpacingAfter = 15f;
            documento.Add(nroAutorizacion);

            Paragraph fecha = new Paragraph();
            fecha.Add(new Chunk("Fecha de Autorización: ", fuenteNegrita));
            fecha.Add(new Chunk(autorizacion.FechaAutorizacion.ToString("dd/MM/yyyy HH:mm"), fuenteNormal));
            fecha.SpacingAfter = 10f;
            documento.Add(fecha);

            documento.Add(new Paragraph(" ")); 

            Paragraph tituloAfiliado = new Paragraph("DATOS DEL AFILIADO", fuenteNegrita);
            tituloAfiliado.SpacingBefore = 10f;
            tituloAfiliado.SpacingAfter = 10f;
            documento.Add(tituloAfiliado);

            AgregarLinea(documento, "Nombre y Apellido:", autorizacion.Afiliado.NombreApellido, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "CUIL:", autorizacion.Afiliado.Cuil, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "Teléfono:", autorizacion.Afiliado.Telefono, fuenteNegrita, fuenteNormal);

            documento.Add(new Paragraph(" ")); 

            Paragraph tituloPractica = new Paragraph("PRÁCTICA AUTORIZADA", fuenteNegrita);
            tituloPractica.SpacingBefore = 10f;
            tituloPractica.SpacingAfter = 10f;
            documento.Add(tituloPractica);

            AgregarLinea(documento, "Práctica:", autorizacion.Practica.Nombre, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "Código:", autorizacion.Practica.Codigo.ToString(), fuenteNegrita, fuenteNormal);

            documento.Add(new Paragraph(" ")); 

            Paragraph tituloPrestador = new Paragraph("PRESTADOR AUTORIZADO", fuenteNegrita);
            tituloPrestador.SpacingBefore = 10f;
            tituloPrestador.SpacingAfter = 10f;
            documento.Add(tituloPrestador);

            AgregarLinea(documento, "Razón Social:", autorizacion.Prestador.RazonSocial, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "CUIT:", autorizacion.Prestador.Cuit, fuenteNegrita, fuenteNormal);
        }
        private static void AgregarLinea(Document documento, string etiqueta, string valor, Font fuenteEtiqueta, Font fuenteValor)
        {
            Paragraph linea = new Paragraph();
            linea.Add(new Chunk(etiqueta + " ", fuenteEtiqueta));
            linea.Add(new Chunk(valor, fuenteValor));
            linea.SpacingAfter = 5f;
            documento.Add(linea);
        }
        private static void AgregarPieDePagina(Document documento)
        {
            documento.Add(new Paragraph(" ")); 
            documento.Add(new Paragraph(" ")); 

            documento.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));

            Font fuentePequena = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.GRAY);
            Paragraph pie = new Paragraph(
                "Este documento es una autorización médica válida. Conserve este comprobante.\n" +
                "Para consultas comuníquese con nuestra línea de atención.\n" + 
                "GNR SALUD",
                fuentePequena
            );
            pie.Alignment = Element.ALIGN_CENTER;
            pie.SpacingBefore = 10f;
            documento.Add(pie);
        }

        #endregion

        #region recibo
        public static string GenerarPDFRecibo(BEFactura factura)
        {
            try
            {
                BEPago pago = factura.Pago;

                string carpetaPDFs = Path.Combine(ServicioDirectorio.RutaPDFs, "Recibos");

                if (!Directory.Exists(carpetaPDFs))
                    Directory.CreateDirectory(carpetaPDFs);

                string nombreArchivo = $"Recibo_{pago.NumeroRecibo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(carpetaPDFs, nombreArchivo);

                Document documento = new Document(PageSize.A4);
                PdfWriter.GetInstance(documento, new FileStream(rutaCompleta, FileMode.Create));

                documento.Open();

                AgregarEncabezadoRecibo(documento);
                AgregarDatosRecibo(documento, factura);
                AgregarPieDePaginaRecibo(documento);

                documento.Close();

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar PDF de recibo: " + ex.Message);
            }
        }
        private static void AgregarEncabezadoRecibo(Document documento)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
            Paragraph titulo = new Paragraph("RECIBO DE PAGO", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            documento.Add(titulo);

            documento.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));
            documento.Add(new Paragraph(" "));
        }
        private static void AgregarDatosRecibo(Document documento, BEFactura factura)
        {
            BEPago pago = factura.Pago;

            Font fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            Paragraph nroRecibo = new Paragraph();
            nroRecibo.Add(new Chunk("Nº de Recibo: ", fuenteNegrita));
            nroRecibo.Add(new Chunk(pago.NumeroRecibo.ToString(),
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLUE)));
            nroRecibo.SpacingAfter = 15f;
            documento.Add(nroRecibo);

            Paragraph fecha = new Paragraph();
            fecha.Add(new Chunk("Fecha de Pago: ", fuenteNegrita));
            fecha.Add(new Chunk(pago.FechaPago.ToString("dd/MM/yyyy HH:mm"), fuenteNormal));
            fecha.SpacingAfter = 10f;
            documento.Add(fecha);

            Paragraph formaPago = new Paragraph();
            formaPago.Add(new Chunk("Forma de Pago: ", fuenteNegrita));
            formaPago.Add(new Chunk(pago.FormaPago, fuenteNormal));
            formaPago.SpacingAfter = 15f;
            documento.Add(formaPago);

            documento.Add(new Paragraph(" "));

            Paragraph tituloPrestador = new Paragraph("DATOS DEL PRESTADOR", fuenteNegrita);
            tituloPrestador.SpacingBefore = 10f;
            tituloPrestador.SpacingAfter = 10f;
            documento.Add(tituloPrestador);

            AgregarLinea(documento, "Razón Social:", factura.Prestador.RazonSocial, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "CUIT:", factura.Prestador.Cuit, fuenteNegrita, fuenteNormal);

            documento.Add(new Paragraph(" "));

            Paragraph tituloFactura = new Paragraph("DETALLE DE FACTURA CANCELADA", fuenteNegrita);
            tituloFactura.SpacingBefore = 10f;
            tituloFactura.SpacingAfter = 10f;
            documento.Add(tituloFactura);

            AgregarLinea(documento, "Nº de Factura:", factura.Numero.ToString(), fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "Fecha Factura:", factura.FechaRecibida.ToString("dd/MM/yyyy"), fuenteNegrita, fuenteNormal);

            if (factura.Autorizacion != null)
            {
                AgregarLinea(documento, "Nº Autorización:", factura.Autorizacion.NumeroAutorizacion.ToString(), fuenteNegrita, fuenteNormal);
            }

            documento.Add(new Paragraph(" "));

            PdfPTable tablaMonto = new PdfPTable(2);
            tablaMonto.WidthPercentage = 100;
            tablaMonto.SpacingBefore = 20f;
            tablaMonto.SpacingAfter = 20f;

            PdfPCell celdaEtiqueta = new PdfPCell(new Phrase("MONTO PAGADO:", fuenteNegrita));
            celdaEtiqueta.BackgroundColor = new BaseColor(240, 240, 240);
            celdaEtiqueta.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaEtiqueta.Padding = 10f;
            celdaEtiqueta.Border = Rectangle.NO_BORDER;
            tablaMonto.AddCell(celdaEtiqueta);

            Font fuenteMonto = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);
            PdfPCell celdaMonto = new PdfPCell(new Phrase($"$ {pago.Monto:N2}", fuenteMonto));
            celdaMonto.BackgroundColor = new BaseColor(240, 240, 240);
            celdaMonto.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaMonto.Padding = 10f;
            celdaMonto.Border = Rectangle.NO_BORDER;
            tablaMonto.AddCell(celdaMonto);

            documento.Add(tablaMonto);
        }
        private static void AgregarPieDePaginaRecibo(Document documento)
        {
            documento.Add(new Paragraph(" "));
            documento.Add(new Paragraph(" "));

            documento.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator())));

            Font fuentePequena = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.GRAY);
            Paragraph pie = new Paragraph(
                "Este documento certifica el pago realizado. Conserve este recibo como comprobante.\n" +
                "Válido como comprobante de pago ante cualquier reclamo.\n" +
                "GNR SALUD",
                fuentePequena
            );
            pie.Alignment = Element.ALIGN_CENTER;
            pie.SpacingBefore = 10f;
            documento.Add(pie);

            documento.Add(new Paragraph(" "));
            Font fuenteFirma = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.LIGHT_GRAY);
            Paragraph firma = new Paragraph(
                $"Documento generado electrónicamente el {DateTime.Now:dd/MM/yyyy HH:mm:ss}",
                fuenteFirma
            );
            firma.Alignment = Element.ALIGN_CENTER;
            documento.Add(firma);
        }
        #endregion
    }
}