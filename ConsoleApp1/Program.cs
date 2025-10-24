
// declaro las variables
using ConsoleApp1;

//bool mostrarResultado = true;
//decimal numero1, numero2, resultado = 0;
//string textoResultado = "El resultado es: ";
//string? operacion = string.Empty;
//ConsoleKeyInfo? keyinfo;


//// hago las operaciones con las variables
//numero1 = 10;
//numero2 = 15;

//// Imprimir mensaje de operacion que quiere el usuario
//Console.WriteLine("Ingrese la operación que desea aplicar: +,-,*,/");

//// lee la operacion definida por el usuario
//keyinfo = Console.ReadKey();
//Console.WriteLine();

///// transforma la opcion ingresada por el usuario
///// para extraer el caracter
//operacion = keyinfo.Value.KeyChar.ToString();

//// aplico la operacion
//switch (operacion)
//{
//	case "+": resultado = numero1 + numero2;
//		break;

//	case "-": resultado = numero1 - numero2;
//		break;

//	case "*": resultado = numero1 * numero2;
//		break;

//	case "/": resultado = numero1 / numero2;
//		break;

//	case "$":
//		{
//            for (int i = 0; i < 4; i++)
//            {
//				resultado = resultado + 1;
//			}
//        }
//        break;

//    case "%":
//        {
//            int i = 0;
//            while(i < 5)
//            {
//                resultado = resultado + 1;
//                i++;
//            }
//        }
//        break;

//    default:
//        // muestra mensaje en caso de que la operacion no sea valida
//        Console.WriteLine("Operación no reconocida");
//        mostrarResultado = false;
//        resultado = 0;
//		break;
//}

//// imprime el resultado de la operación

//if (mostrarResultado)
//{
//    Console.WriteLine(textoResultado + resultado);
//}


IAposento aposento = new Cuarto();
aposento.nombre = "Cuarto Walter";

IAposento aposento2 = new Cocina() { nombre = "Cocina Juanpa" };


IAposento aposento3 = new Sala();
aposento3.nombre = "Mi Sala";


Console.WriteLine(aposento.nombre);
Console.WriteLine(aposento2.nombre);
Console.WriteLine(aposento3.nombre);

//Casa
//    Lista de aposentos


//Aposentos (Cuartos, Baño, Sala, Comedor, Cocina, Pilas, Corredor, Cochera)

//Aposentos 
//    - Nombre
//    - Medida m2
//    - Muebles




