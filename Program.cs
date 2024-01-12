using System;

public class Answer {
    static void Main(string[] args){
        int num, quantity = 0;

        //Console.Clear();
        Console.WriteLine("Введите число от 1 до 100_000 включительно, если хотите ввести число с клавиатуры;");
        Console.WriteLine("Введите 0, если хотите получить рандомное число.");
    
        while (true){
            String? str = Console.ReadLine();

            if (!int.TryParse(str, out num)){
                Console.WriteLine("Вы ввели не число!");
                continue;
            }

            if (num == 0){
                num = new Random().Next(1,100_000);
                int temp = num;
                while(temp > 0){
                    temp/=10;
                    quantity++;
                }
                Console.WriteLine($"Рандомное число {num} состоит из {quantity} цифр.");
                break;
            }

            if (num >= 1 && num <= 100_000){
                quantity = string.Join("",num).Length;
                Console.WriteLine($"Ваше число {num} состоит из {quantity} цифр.");
                break;
            } else {
                Console.WriteLine($"Число {num} не из диапазона [1 ; 100_000]");
            }
        }
        
        int[] digits = new int[quantity];
        int number = num;
        
        for (int i = 0; i < quantity; i++){
            int pow = Convert.ToInt32(Math.Pow(10, quantity - 1 - i));
            digits[i] = num / pow;
            num %= pow;
        }

        String str2 = string.Join(", ", digits);
        Console.WriteLine($"Из числа {number} получаем массив:[{str2}]");
    }
}