using numl.Math.LinearAlgebra;
using numl.Supervised.Regression;
using System;

namespace ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // numeros de restaurantes (con ratings)
            var n = 200;

            // numero de caracteristicas en las que esta evaluado cada restaurante
            //las caracteristicas pueden ir desde mexicano, a leña, artesanal, comida rapida, pastas
            //estas informaciones hacen que el algoritmo prediga el gusto del usuario de manera mas acertada
            var m = 5;

            // inicializando la matriz de caracteristicas (como cada restaurante esta evaluado en base a 1000 en cada categoria)
            // y el vector usuario (como un usuario especifico clasifico en base a 5 estrellas cada restaurante)
            // con valores random
            Matrix x = new Matrix(n, m);
            Vector y = new Vector(n);
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                // los ratings son en un rango de 0-5
                y[i] = rnd.Next(0, m);

                // la valoracion de cada categoria es en un rango de 0-1000
                for (var j = 0; j < m; j++)
                {
                    x[i, j] = rnd.Next(0, 1000);
                }
            };

            // creando supervised learning model que usa el algoritmo de regresion lineal
            // adaptando el algoritmo
            LinearRegressionGenerator generator = new LinearRegressionGenerator()
            {
                LearningRate = 0.1,     //  tasa de aprendizaje
                MaxIterations = 400,    // cuantas veces correra el generador
                Lambda = 0              // no entendi esto
            };

            // aqui entrenamos al modelo, aqui es que el machine learning se implementa
            //se introduce la matriz de los libro valorados y la valoracion de varios usuarios que generamos
            // de esta forma el algoritmo conocera al usuario que le dio rating a esos 200 restaurantes y tendra a Theta
            // que son los valores de cada categoria con que predecira los ratings de los proximos restaurantes basado en sus categorias
            LinearRegressionModel model = (LinearRegressionModel)generator.Generate(x.Copy(), y.Copy());

            // aqui muestro en pantalla los valores para cada categoria que van acorde al usuario
            //este es el modelo final
            Console.WriteLine(model.Theta);
            Console.ReadKey();

            // abajo se crean los libros sin rating
            // y para cada uno se predecira el rating que el usuario le daria
            Matrix x_unrated = new Matrix(n, m);
            Vector y_prediccion = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                // la valoracion de cada categoria es en un rango de 0-1000
                for (var j = 0; j < m; j++)
                {
                    x_unrated[i, j] = rnd.Next(0, 1000);
                }

                // en base a al valor de cada categoria, hace una prediccion para el rating
                var unratedBook = new Vector(new double[] {
                    x_unrated[i, 0],
                    x_unrated[i, 1],
                    x_unrated[i, 2],
                    x_unrated[i, 3],
                    x_unrated[i, 4]
                });
                var nuevoRating = model.Predict(unratedBook);
                y_prediccion[i] = nuevoRating;
                Console.WriteLine(y_prediccion[i]);
            };
            Console.ReadKey();
        }
    }
}
