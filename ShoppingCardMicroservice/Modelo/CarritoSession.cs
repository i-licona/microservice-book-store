namespace ShoppingCardMicroservice.Modelo
{
    public class CarritoSession
    {
        public int CarritoSessionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<CarritoSessionDetalle> ListaDetalle { get; set; }
    }
}
