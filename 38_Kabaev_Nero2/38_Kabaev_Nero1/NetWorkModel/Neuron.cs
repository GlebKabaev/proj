using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using static System.Math;

namespace _38_Kabaev_Nero1.NetWorkModel
{
    class Neuron
    {
        private TypeNeyron type; // тип нейрона
        private double[] weight;// веса
        private double[] input;// вход
        private double output;// выход
        private double derr;// производная функции
        private double a = 0.01d;//для функции

        // Свойства
        public double[] Weights { get => weight; set => weight = value; }
        public double[] Inputs { get => input; set => input = value; }
        public double Output { get => output; }
        public double Derr { get => derr; }

        public Neuron(double[] w, TypeNeyron typ)
        {
            type = typ;
            weight = w;
        }
        public void Activator(double[] inpt, double[] wght)
        {
            double sum = wght[0];
            for (int m = 0; m < inpt.Length; m++)
                sum += inpt[m] * wght[m + 1];
            switch (type)
            {
                case TypeNeyron.HiddenNeuron:// для нейронов скрытого слоя
                    output = PerfReLU(sum);
                    //derr = PerfReLU_Derivativator(sum);
                    break;
                case TypeNeyron.OutputNeuron:// для нейронов выходного слоя
                    output = Math.Exp(sum);
                    break;
            }
        }
        private double PerfReLU(double sum) => (sum < 0 )? a * sum : sum;
         private double PerfReLU_Derivativator(double sum) => sum < 0 ? a : 1;
        // private double PerfReLU(double sum) => (sum >= 0) ? sum : a * sum;
        // private double PerfReLU_Derivativator(double sum) => (sum >= 0) ? 1 : a;
    }
}

