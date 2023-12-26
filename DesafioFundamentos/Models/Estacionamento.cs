using System;
using System.Collections.Generic;

namespace SistemaParaUmEstacionamento
{
    class Estacionamento
    {
        private List<string> veiculos = new List<string>(); // Lista de placas dos veículos no estacionamento
        private Dictionary<string, DateTime> horaEntradaVeiculos = new Dictionary<string, DateTime>(); // Hora de entrada de cada veículo
        private Dictionary<string, DateTime> horaSaidaVeiculos = new Dictionary<string, DateTime>(); // Hora de saída de cada veículo
        private Dictionary<string, decimal> valorAPagarVeiculos = new Dictionary<string, decimal>(); // Valor a pagar por cada veículo

        // Método para adicionar um veículo ao estacionamento
        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
            horaEntradaVeiculos[placa] = DateTime.Now; // Registra a hora de entrada como a hora atual
        }

        // Método para remover um veículo do estacionamento
        public void RemoverVeiculo(string placa)
        {
            if (veiculos.Contains(placa))
            {
                veiculos.Remove(placa);
                horaEntradaVeiculos.Remove(placa);
                horaSaidaVeiculos.Remove(placa);
                valorAPagarVeiculos.Remove(placa);
            }
        }

        // Método para listar os veículos no estacionamento
        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos no estacionamento:");
            foreach (var placa in veiculos)
            {
                Console.WriteLine($"Placa: {placa}");
            }
        }

        // Método para registrar a hora de entrada de um veículo
        public void RegistrarHoraEntrada(string placa, DateTime horaEntrada)
        {
            horaEntradaVeiculos[placa] = horaEntrada;
        }

        // Método para registrar a hora de saída de um veículo
        public void RegistrarHoraSaida(string placa, DateTime horaSaida)
        {
            horaSaidaVeiculos[placa] = horaSaida;
        }

        // Método para definir o valor a pagar por um veículo
        public void DefinirValorAPagar(string placa, decimal valorAPagar)
        {
            valorAPagarVeiculos[placa] = valorAPagar;
        }

        // Método para finalizar a estadia de um veículo e calcular o valor a pagar
        public decimal FinalizarVeiculo(string placa)
        {
            decimal precoTotal = 0;
            if (veiculos.Contains(placa) && horaSaidaVeiculos.ContainsKey(placa))
            {
                DateTime horaEntrada = horaEntradaVeiculos[placa];
                DateTime horaSaida = horaSaidaVeiculos[placa];
                TimeSpan permanencia = horaSaida - horaEntrada;
                decimal precoPorHora = valorAPagarVeiculos[placa];
                precoTotal = precoPorHora * (decimal)permanencia.TotalHours;
                RemoverVeiculo(placa); // Remove o veículo após finalizar
            }
            return precoTotal;
        }
    }
}