namespace SmartPark.Borders.Shared.Messages
{
    public static class ResponseMessages
    {
        private static readonly Dictionary<string, Dictionary<int, string>> Messages = new()
        {
            ["ParkingLotsController"] = new Dictionary<int, string>
            {
                [200] = "Estacionamento retornado com sucesso.",
                [201] = "Estacionamento criado com sucesso.",
                [204] = "Estacionamento atualizado com sucesso.",
                [400] = "Erro ao processar estacionamento.",
                [404] = "Estacionamento não encontrado.",
                [500] = "Erro interno ao processar estacionamento."
            }
        };

        public static string GetMessage(string controllerName, int statusCode)
        {
            if (Messages.TryGetValue(controllerName, out var map) && map.TryGetValue(statusCode, out var message))
                return message;

            return "Operação finalizada.";
        }
    }
}
