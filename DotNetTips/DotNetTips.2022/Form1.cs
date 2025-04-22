using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DotNetTips._2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const double FrequenciaBotaoVerde = 329.628; // nota E uma oitava abaixo
        private const double FrequenciaBotaoVermelho = 440; // nota A
        private const double FrequenciaBotaoAmarelo = 554.365; // nota C#
        private const double FrequenciaBotaoAzul = 659.255; // nota E

        private void AcionarBotao(Button btn, Color cor, double frequencia)
        {
            AlterarCorBotao(btn, cor, true);
            Application.DoEvents();

            TocarNotaMusical(frequencia);

            AlterarCorBotao(btn, cor, false);
            Application.DoEvents();
        }

        private void AlterarCorBotao(Button bt, Color cor, bool aplicarLight)
        {
            if (aplicarLight)
            {
                cor = ControlPaint.LightLight(cor);
            }

            bt.BackColor = cor;
        }

        private void TocarNotaMusical(double frequencia)
        {
            var nota = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = frequencia,
                Type = SignalGeneratorType.Triangle
            }
            .Take(TimeSpan.FromSeconds(0.5));

            using (var wo = new WaveOutEvent())
            {
                wo.Init(nota);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NovoJogo();
        }

        private void btnVermelho_Click(object sender, EventArgs e)
        {
            BotoesAcionadosJogador.Add(2);
            AcionarBotao(btnVermelho, Color.Red, FrequenciaBotaoVermelho);
        }

        private void btnAzul_Click(object sender, EventArgs e)
        {
            BotoesAcionadosJogador.Add(4);
            AcionarBotao(btnAzul, Color.Blue, FrequenciaBotaoAzul);
        }

        private void btnVerde_Click(object sender, EventArgs e)
        {
            BotoesAcionadosJogador.Add(1);
            AcionarBotao(btnVerde, Color.Green, FrequenciaBotaoVerde);
        }

        private void btnAmarelo_Click(object sender, EventArgs e)
        {
            BotoesAcionadosJogador.Add(3);
            AcionarBotao(btnAmarelo, Color.Yellow, FrequenciaBotaoAmarelo);
        }

        #region jogo

        private int JogadorVez = 0;// 0 = cpu, 1 = jogador 1
        private List<int> BotoesAcionadosJogo = new List<int>();
        private List<int> BotoesAcionadosJogador = new List<int>();
        private int EstadoJogo = 0;// 0 parado, 1 = jogando, 99 = gameover;

        private void NovoJogo()
        {
            JogadorVez = 0;
            EstadoJogo = 1;

            while (EstadoJogo == 1)
            {
                LoopJogo();
                Application.DoEvents();
                Thread.Sleep(100);
            }

            Application.DoEvents();
        }

        private void LoopJogo()
        {
            switch (JogadorVez)
            {
                case 0:
                    lbJogadorVez.Text = "Computador jogando";
                    JogadaMaquina();
                    break;

                default:
                    lbJogadorVez.Text = "Jogador " + JogadorVez;
                    JogadaJogador(JogadorVez);
                    break;
            }
        }

        private void JogadaJogador(int jogador)
        {
            int indiceLista = 0;
            foreach (var botaoJogador in BotoesAcionadosJogador)
            {
                if (BotoesAcionadosJogo[indiceLista] != botaoJogador)
                {
                    //jogador errou
                    // fim de jogo
                    EstadoJogo = 99;
                }

                if (indiceLista <= BotoesAcionadosJogo.Count)
                {
                    indiceLista++;
                }
            }

            if (EstadoJogo == 99)
            {
                FimDeJogo();
            }

            if (BotoesAcionadosJogador.Count == BotoesAcionadosJogo.Count)
            {
                JogadorVez = 0;
                BotoesAcionadosJogador.Clear();
            }
        }

        private void JogadaMaquina()
        {
            //quantidadeToques++;
            Random rnd = new Random();

            // passa pelos que já estão na memória
            foreach (var item in BotoesAcionadosJogo)
            {
                switch (item)
                {
                    case 1: // verde
                        AcionarBotao(btnVerde, Color.Green, FrequenciaBotaoVerde);
                        break;

                    case 2: // vermelho
                        AcionarBotao(btnVermelho, Color.Red, FrequenciaBotaoVermelho);
                        break;

                    case 3: // amarelo
                        AcionarBotao(btnAmarelo, Color.Yellow, FrequenciaBotaoAmarelo);
                        break;

                    case 4: // azul
                        AcionarBotao(btnAzul, Color.Blue, FrequenciaBotaoAzul);
                        break;
                }
            }

            // adiciona mais um a cada jogada
            int numeroCor = rnd.Next(1, 5);
            switch (numeroCor)
            {
                case 1: // verde
                    BotoesAcionadosJogo.Add(1);
                    AcionarBotao(btnVerde, Color.Green, FrequenciaBotaoVerde);
                    break;

                case 2: // vermelho
                    BotoesAcionadosJogo.Add(2);
                    AcionarBotao(btnVermelho, Color.Red, FrequenciaBotaoVermelho);
                    break;

                case 3: // amarelo
                    BotoesAcionadosJogo.Add(3);
                    AcionarBotao(btnAmarelo, Color.Yellow, FrequenciaBotaoAmarelo);
                    break;

                case 4: // azul
                    BotoesAcionadosJogo.Add(4);
                    AcionarBotao(btnAzul, Color.Blue, FrequenciaBotaoAzul);
                    break;
            }

            JogadorVez = 1;
            BotoesAcionadosJogador = new List<int>();
        }

        private void FimDeJogo()
        {
            EstadoJogo = 0;
            lbJogadorVez.Text = "Fim de Jogo";
            BotoesAcionadosJogo.Clear();
            BotoesAcionadosJogador.Clear();
        }

        #endregion jogo
    }
}