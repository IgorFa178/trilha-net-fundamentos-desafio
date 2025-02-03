using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placaVeiculo;
            Console.WriteLine("Digite a placa sem traços para estacionar o veículo:");

            placaVeiculo = (Console.ReadLine().ToUpper());
            if (veiculos.Contains(placaVeiculo))
            {
                Console.WriteLine("Esse veículo ja está estacionado, favor verifique se inseriu a placa corretamente.");
            }
            else
            {
                veiculos.Add(placaVeiculo);
                Console.WriteLine("Veiculo estacionado com sucesso!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa sem traços para remover o veículo:");

          
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                decimal valorTotal = 0;
                bool checaHoras;

                checaHoras = decimal.TryParse(Console.ReadLine().Replace('.',','),out decimal horasNoEstacionamento);
                while (checaHoras != true)
                {
                    Console.WriteLine("Valor não inserido corretamente, por favor insira a quantidade de horas em que o veiculo ficou estacionado:");
                    checaHoras = decimal.TryParse(Console.ReadLine().Replace('.',','),out horasNoEstacionamento);
                };


                valorTotal = Math.Round((precoInicial + horasNoEstacionamento * precoPorHora),2);

                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine($"Existe um total de {veiculos.Count} veículos no estacionamento. Os veículos estacionados são:");
             
                int contagemVeiculos = 1;
                
                foreach (var listVeiculos in veiculos) 
                {
                    Console.WriteLine($"Veiculo {contagemVeiculos} placa : {listVeiculos}");
                    contagemVeiculos++;
                };
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
