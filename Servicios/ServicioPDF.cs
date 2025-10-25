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
        public static string GenerarPDFAutorizacion(BEAutorizacion autorizacion)
        {
            try
            {
                // ruta pdfs 
                string carpetaPDFs = Path.Combine(ServicioDirectorio.RutaPDFs, "Autorizaciones");

                // creamos la carpeta si no existe
                if (!Directory.Exists(carpetaPDFs))
                    Directory.CreateDirectory(carpetaPDFs);

                // nombre del archivo
                string nombreArchivo = $"Autorizacion_{autorizacion.NumeroAutorizacion}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(carpetaPDFs, nombreArchivo);

                Document documento = new Document(PageSize.A4);
                PdfWriter.GetInstance(documento, new FileStream(rutaCompleta, FileMode.Create));

                documento.Open();

                // agregamos el contenido
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
            // titulo
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

            // nro de autorizacion
            Paragraph nroAutorizacion = new Paragraph();
            nroAutorizacion.Add(new Chunk("Nº de Autorización: ", fuenteNegrita));
            nroAutorizacion.Add(new Chunk(autorizacion.NumeroAutorizacion.ToString(),
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED)));
            nroAutorizacion.SpacingAfter = 15f;
            documento.Add(nroAutorizacion);

            // fecha
            Paragraph fecha = new Paragraph();
            fecha.Add(new Chunk("Fecha de Autorización: ", fuenteNegrita));
            fecha.Add(new Chunk(autorizacion.FechaAutorizacion.ToString("dd/MM/yyyy HH:mm"), fuenteNormal));
            fecha.SpacingAfter = 10f;
            documento.Add(fecha);

            documento.Add(new Paragraph(" ")); 

            // datos del afiliado
            Paragraph tituloAfiliado = new Paragraph("DATOS DEL AFILIADO", fuenteNegrita);
            tituloAfiliado.SpacingBefore = 10f;
            tituloAfiliado.SpacingAfter = 10f;
            documento.Add(tituloAfiliado);

            AgregarLinea(documento, "Nombre y Apellido:", autorizacion.Afiliado.NombreApellido, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "CUIL:", autorizacion.Afiliado.Cuil, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "Nº de Afiliado:", autorizacion.Afiliado.NroAfiliado.ToString(), fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "Teléfono:", autorizacion.Afiliado.Telefono, fuenteNegrita, fuenteNormal);

            documento.Add(new Paragraph(" ")); 

            // datos de la practica
            Paragraph tituloPractica = new Paragraph("PRÁCTICA AUTORIZADA", fuenteNegrita);
            tituloPractica.SpacingBefore = 10f;
            tituloPractica.SpacingAfter = 10f;
            documento.Add(tituloPractica);

            AgregarLinea(documento, "Práctica:", autorizacion.Practica.Nombre, fuenteNegrita, fuenteNormal);
            AgregarLinea(documento, "Código:", autorizacion.Practica.Codigo.ToString(), fuenteNegrita, fuenteNormal);

            documento.Add(new Paragraph(" ")); 

            // datos del prestador
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
    }
}