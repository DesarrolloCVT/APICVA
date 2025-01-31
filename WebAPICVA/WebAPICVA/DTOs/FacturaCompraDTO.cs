namespace WebAPICVA.DTOs
{
    public class FacturaCompraDTO
    {
        public int Folio { get; set; }
        public string Proveedor { get; set; }
        public string Fecha { get; set; }
        public string Moneda { get; set; }
        public int Total { get; set; }
    }
}
