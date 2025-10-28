namespace SmartPark.Borders.Shared.Messages
{
    public static class ValidationMessages
    {
        public const string NameRequired = "O nome do estacionamento é obrigatório.";
        public const string NameMaxLength = "O nome não pode exceder 100 caracteres.";

        public const string AddressRequired = "O endereço é obrigatório.";
        public const string StreetRequired = "O logradouro é obrigatório.";
        public const string NumberPositive = "O número do endereço deve ser maior que zero.";
        public const string CityRequired = "A cidade é obrigatória.";
        public const string StateRequired = "O estado é obrigatório.";
        public const string ZipCodeRequired = "O CEP é obrigatório.";
        public const string ZipCodeInvalidFormat = "O CEP deve estar no formato 00000-000.";

        public const string CarSpotsNonNegative = "A quantidade de vagas para carros não pode ser negativa.";
        public const string MotorcycleSpotsNonNegative = "A quantidade de vagas para motos não pode ser negativa.";
    }
}
