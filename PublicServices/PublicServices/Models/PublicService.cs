namespace PublicServices.Models
{
    using Newtonsoft.Json;

    public class PublicService
    {
        [JsonProperty(PropertyName = "codigo")]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "institucion")]
        public string Institucion { get; set; }

        [JsonProperty(PropertyName = "unidad_responsable")]
        public string UnidadResponsable { get; set; }

        [JsonProperty(PropertyName = "costo")]
        public string Costo { get; set; }

        [JsonProperty(PropertyName = "tiempo")]
        public string Tiempo { get; set; }

        [JsonProperty(PropertyName = "forma_acceso")]
        public string FormaAcceso { get; set; }

        [JsonProperty(PropertyName = "detalle")]
        public string Detalle { get; set; }
    }
}
