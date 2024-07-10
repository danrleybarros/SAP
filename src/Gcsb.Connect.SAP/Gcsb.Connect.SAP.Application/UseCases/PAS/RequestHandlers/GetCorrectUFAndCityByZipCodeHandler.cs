using Gcsb.Connect.SAP.Application.Repositories.GF;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public class GetCorrectUFAndCityByZipCodeHandler : Handler
    {
        public GetCorrectUFAndCityByZipCodeHandler(IDne dne)
        {
            this.DNE = dne;
        }

        public IDne DNE { get; }

        public override void ProcessRequest(PASChainRequest request)
        {
            request.Lines.ToList().ForEach(f =>
            {
                // Atualiza UF com lista fixa             
                f.Value.ForEach(i => i.ChangeState(Util.GetUFByState(i.State, f.Key)));

                // TODO: Remover alterações abaixo, isso é temporário por conta de nossa massa de dados incorreta referente a endereços
                // Obtem CEPs e remove ceps incorretos conhecidos de nossa massa de dados 
                var ceps = f.Value.Select(s => s.CEP.ToString().PadLeft(8, '0')).Distinct().Where(s => s != "11111111" && s != "04814123").ToList();
                //var ceps = request.Lines.Select(s => s.CEP.ToString().PadLeft(8, '0')).Distinct().ToList();
                var listAddress = DNE.GetListLogradouro(ceps).Result;

                // Atualiza UF/Cidade divergente, usando CEP            
                foreach (var i in f.Value)
                {
                    var city = listAddress.Where(s => s.Cep == i.CEP.ToString().PadLeft(8, '0')).Select(s => s.NomeLocalidade).FirstOrDefault();
                    var state = listAddress.Where(s => s.Cep == i.CEP.ToString().PadLeft(8, '0')).Select(s => s.Uf).FirstOrDefault();
                    if (city != null)
                        i.ChangeCity(city);
                    if (state != null)
                        i.ChangeState(state);
                }
            });

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
