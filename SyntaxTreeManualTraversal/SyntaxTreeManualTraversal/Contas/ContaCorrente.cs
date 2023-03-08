using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Banco.Titular;


namespace Banco.Contas
{
    internal class ContaCorrente
    {

        private static int count = 0;
        public static int TotaldeContasCriadas { get; private set; }

        private int numero_agencia;

        public int Numero_agencia
        {
            get { return this.numero_agencia; }

            private set
            {
                if (value > 0)
                {
                    this.numero_agencia = value;
                }
            }
        }
        public string Conta { get; set; }
        private double saldo = 100;
        public Cliente Titular { get; set; }



        //metodos
        public void Depositar(double valor)
        {
            saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                destino.saldo += valor;
                return true;
            }
        }

        public void SetSaldo(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            else
            {
                this.saldo = valor;
            }
        }

        public double GetSaldo()
        {
            return this.saldo;

        }

        public ContaCorrente(int numero_agencia, string numero_conta)
        {
            this.numero_agencia = numero_agencia;
            this.Conta = numero_conta;

            TotaldeContasCriadas++;
        }

        public ContaCorrente(Cliente titular, int numero_agencia, string conta)
        {
            Titular = titular;
            Numero_agencia = numero_agencia;
            Conta = conta;
        }

        public ContaCorrente()
        {

        }


        //Metodos para imprimir todos os construtores

        public void ImprimeConstrutores(Type pTipo)
        {
            Console.WriteLine("Imprimindo os construtores da Classe Conta Corrente");
            Console.WriteLine(" ");

            ConstructorInfo[] construtores = pTipo.GetConstructors();
            Console.WriteLine("Existe " + construtores.Length + " construtores.");
            Console.WriteLine(" ");

            foreach (ConstructorInfo construtor in construtores)
            {
                //Console.WriteLine("Nome = " + construtor.Name);

                ParameterInfo[] parametros = construtor.GetParameters();

                if (parametros.Length > 0)
                    Console.WriteLine(" ------ Parametros do Construtor  ------ ");

                foreach (ParameterInfo parametro in parametros)
                {
                    Console.WriteLine("Posição = " + parametro.Position);
                    Console.WriteLine("Nome = " + parametro.Name);
                    //Console.WriteLine("Tipo = " + parametro.GetType());
                    Console.WriteLine(" ");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine("===================================================");
            Console.WriteLine(" ");

        }


        //Metodos para imprimir todos os campos da Classe

        public void ImprimeCampos(Type pTipo)
        {
            Console.WriteLine("Imprimindo os campos da Classe Conta Corrente");
            Console.WriteLine(" ");

            FieldInfo[] campos = pTipo.GetFields();

            Console.WriteLine("Existe " + campos.Length + " campos.");
            Console.WriteLine(" ");

            foreach (FieldInfo campo in campos)
            {
                Console.WriteLine("Nome Campo = " + campo.Name);
                Console.WriteLine("Tipo = " + campo.GetType());
                Console.WriteLine("É Serializado = " + !campo.IsNotSerialized);
                Console.WriteLine("É privado = " + campo.IsPrivate);
                Console.WriteLine("É Estático = " + campo.IsStatic);
                Console.WriteLine(" ");
            }
            Console.WriteLine("===================================================");
            Console.WriteLine(" ");
        }


        //Metodos para imprimir todas as propriedades da Classe
        public void ImprimePropriedades(Type pTipo)
        {
            Console.WriteLine("Impirmindo as propriedades da Classe Conta Corrente");
            Console.WriteLine(" ");

            //Obtem propriedades atraves do metodo GetProperties
            PropertyInfo[] props = pTipo.GetProperties();

            Console.WriteLine("Existe " + props.Length + " propriedades. ");
            Console.WriteLine(" ");

            foreach (PropertyInfo propriedade in props)
            {
                Console.WriteLine("Nome = " + propriedade.Name);
                //Console.WriteLine("Tipo = " + propriedade.GetType());
                //Console.WriteLine("Leitura = " + propriedade.CanRead);
                //Console.WriteLine("Escrita = " + propriedade.CanWrite);
                Console.WriteLine(" ");
            }

            Console.WriteLine("===================================================");
            Console.WriteLine(" ");
        }

        //Metodos para imprimir todas as interfaces que o objeto implementa
        public void ImprimeInterfaces(Type pTipo)
        {
            Console.WriteLine("Imprimindo as interfaces implementadas pela classe Conta Corrente");
            Console.WriteLine(" ");

            //Obtem as interfaces atraves do metodo GetInterfaces
            Type[] interfaces = pTipo.GetInterfaces();
            Console.WriteLine("Existe " + interfaces.Length + " interfaces implementadas. ");
            Console.WriteLine(" ");

            foreach (Type auxiliar in interfaces)
            {
                Console.WriteLine("Nome = " + auxiliar.FullName);
            }
            Console.WriteLine("===================================================");
            Console.WriteLine(" ");
        }


        //Metodos para imprimir os atributos da classe
        public void ImprimeAtributos(Type pTipo)
        {
            Console.WriteLine("Imprimindo os atributos da Classe Conta Corrente");
            Console.WriteLine(" ");

            Object[] atributos = pTipo.GetCustomAttributes(true);
            Console.WriteLine("Existe " + atributos.Length + " atributos.");
            Console.WriteLine(" ");

            foreach (Object atributo in atributos)
            {
                Console.WriteLine("Tipo = " + atributo.GetType());
            }
            Console.WriteLine("===================================================");
            Console.WriteLine(" ");
        }


        //Metodo para imprimir os metodos da classe
        public void ImprimeMetodos(Type pTipo)
        {
            Console.WriteLine("Imprimindo os metodos da Classe COnta Corrente");
            Console.WriteLine(" ");

            MethodInfo[] metodos = pTipo.GetMethods();

            Console.WriteLine("Existe " + metodos.Length + " metodos");
            Console.WriteLine(" ");

            foreach (MethodInfo metodo in metodos)
            {
                Console.WriteLine("Nome = " + metodo.Name);
                Console.WriteLine("É privado = " + metodo.IsPrivate);
                Console.WriteLine("É estático = " + metodo.IsStatic);

                ParameterInfo[] parametros = metodo.GetParameters();

                if (parametros.Length > 0)

                    //Console.WriteLine("----- Parametros do metodo -----");

                    foreach (ParameterInfo parametro in parametros)
                    {
                        Console.WriteLine("Posicao = " + parametro.Position);
                        Console.WriteLine("Nome = " + parametro.Name);
                        Console.WriteLine("É de entrada = " + parametro.IsIn);
                        Console.WriteLine("É de saida = " + parametro.IsOut);
                        Console.WriteLine(" ");
                    }

            }
            Console.WriteLine("===================================================");
            Console.WriteLine(" ");
        }
    }
}
