namespace GenPDFGateway.WebApi.Contracts.v1.DTO
{

    public class Context
    {
        public string addressee_name { get; set; }
        public string desired_position { get; set; }
        public string relevant_areas { get; set; }
        public string author_name { get; set; }
        public string? current_date { get; set; }
    }


    public class Generator
    {
        public string template_id { get; set; }
        public Context context { get; set; }
    }


}
