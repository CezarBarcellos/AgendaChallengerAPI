using Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace AgendaChallenger.Domain.Utils
{
    public static class Utils
    {
        public static string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static List<Compromisso> LstEventToLstCompromisso(IList<Google.Apis.Calendar.v3.Data.Event> eventos)
        {
            var compromissos = new List<Compromisso>();

            foreach (var evento in eventos)
            {
                // Garante que o evento tenha Start e End válidos
                if (evento.Start?.DateTime == null || evento.End?.DateTime == null)
                    continue;

                var compromisso = new Compromisso(
                    id: evento.Id,
                    titulo: evento.Summary ?? "(Sem título)",
                    descricao: evento.Description ?? string.Empty,
                    dataInicio: evento.Start.DateTime.Value,
                    dataFim: evento.End.DateTime.Value,
                    localizacao: evento.Location,
                    status: (int)(evento.Status == "cancelled" ? 0 : 1) // 0 = cancelado, 1 = ativo
                );

                compromissos.Add(compromisso);
            }

            return compromissos;
        }
    }
}
