void PrintArray(int [] arr)
{
    Console.WriteLine();
    foreach(int i in arr)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}
void PrintStrArray(string [] arr)
{
    Console.WriteLine();
    foreach(string i in arr)
    {
        Console.Write(i + " ");
    }
    
}
int [] FillRandomArray(int length, int minVal = -100, int maxVal = 100)
{
    int [] arr = new int [length];
    for(int i = 0; i < length; i++)
    {
        arr[i] = new Random().Next(minVal,maxVal);
    }
    return arr;
}
//Первая задача
int Power(int a, int b)
{
    if(b>=0)
    {
        int p = a;
        for(int i=1; i<b; i++)
            a *= p;
        return a;
    }
    else
    {
        Console.Write("Степень неположительная:");
        return b;
    }

}
void inputNum(string s = "Введите число:")
{
    Console.Write(s);
}
inputNum();
int a = int.Parse(Console.ReadLine());
inputNum("Введите степень, в которую нужно возвести число:");
int b = int.Parse(Console.ReadLine());
Console.WriteLine(Power(a,b));


///Вторая задача
int sumNum(int a)
{
    int sum = 0;
    while(a != 0)
    {
        sum += a%10;
        a = a/10;
    }
    return sum;
}

inputNum();
int c = int.Parse(Console.ReadLine());
Console.Write(sumNum(c));

///Третья задача
int [] sumNumArr(int [] arr)
{
    int len = arr.Length;
    int [] arr1 = new int[len];
    for(int i = 0; i < len; i++)
        arr1[i] = sumNum(arr[i]);
    return arr1;
}

int [] arr = FillRandomArray(8,100,9999);
PrintArray(arr);
int [] arr1 = sumNumArr(arr);
PrintArray(arr1);

// Задача перенести нули в левую часть массива
int [] arr3 = FillRandomArray(15, -2,1);
PrintArray(arr3);
int [] sortArr(int [] arr)
{
    int length = arr.Length;
    int counter = 0;
    int temp = 0;
    for(int i = 0; i<length; i++)
    {
        if(arr[i] == 0)
        {
            if(arr[counter]!=0)
            {
                temp = arr[counter];
                arr[counter] = 0;
                arr[i] = temp;
            }
            counter++;  //На семинаре у нас в паре была ошибка, counter перенес за скобки
        }
    }
    return arr;
}
int[] arr4 = sortArr(arr3);
PrintArray(arr4);


/////Дополнительная задача №2 была решена на семинаре

/////Дополнительная задача №3


////Программа принимает 8 пар чисел от 1 до 8
////Каждая пара чисел вводится с новой строки через пробел
// В итоге выводится No если нет бьющих друг друга ферзей, иначе Yes
//Также рисуется матрица расположения ферзей
int [,] FillArraySpaces(int str, int cols)
{
    int counter = 0;
    string s;
    string[] subs;
    int [,] arr = new int [str, cols];
    Console.WriteLine("Введите массив через пробел:");
    while(counter<str)
    {
        s =  Console.ReadLine(); 
        subs = s.Split();
        for(int i = 0; i<cols;i++)
            arr[counter,i] = int.Parse(subs[i]);
        counter++;
    }
    return arr;
}

void PrintIntMultiArr(int [,] arr)
{
    foreach(int i in arr)
        Console.Write(i + " ");

    Console.WriteLine();
}
// int [,] coord = {{1,6},{2,4},{3,1},{4,5},{5,8},{6,2},{7,7},{8,3}};
// int [,] coord = {{5,1},{6,1},{7,1},{8,1},{5,2},{6,2},{7,2},{8,2}};
int [,] coord = FillArraySpaces(8,2);
PrintIntMultiArr(coord);
void PrintTable(int [,] strikes, int [,] coord)
{
    int colString = strikes.GetLength(0);
    int str = 8;
    string []s=new string[str];
        for(int i = str-1; i>=0; i--)
        {
            for(int j = 0; j<str; j++)
            {

                for(int k = 0; k<colString; k++)
                {
                    if(strikes[k,0] == j+1 && strikes[k,1] == i+1)
                    {
                        s[j] = "+ ";
                        break;
                    }
                    else
                    {
                        s[j] = "O ";
                    }
                }
                for(int n = 0; n<str; n++)
                    if(coord[n,0] == j+1 && coord[n,1] == i+1)
                    {
                        s[j] = "Q ";
                    }
            }
            PrintStrArray(s);
        }

}
int[,] fStrike(int [,] coord)
{
    bool strike = false;
    int lim = 8;
    List<List<int>> coordStriked = new List<List<int>>(); 
    int x,y;
    int counter=0;
    int c = 0;
    for(int i = 0; i<lim; i++)
    {
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(x == lim || y == lim)
                break;
            coordStriked.Add(new List<int>());
            coordStriked[j].Add(++x);
            coordStriked[j].Add(++y);
            c++;
        }
        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(y == lim)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(x);
            coordStriked[j].Add(++y);
            c++;
        }

        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(x == lim)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(++x);
            coordStriked[j].Add(y);
            c++;
        }

        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(x==lim || y == 1)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(++x);
            coordStriked[j].Add(--y);
            c++;
        }
        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(y==1)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(x);
            coordStriked[j].Add(--y);
            c++;
        }
        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(x == 1 || y == 1)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(--x);
            coordStriked[j].Add(--y);
            c++;
        }

        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim+counter; j++)
        {
            if(x==1)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(--x);
            coordStriked[j].Add(y);
            c++;
        }
        counter=c;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = c; j<lim +counter; j++)
        {
            if(x==1 || y == lim)
                break;

            coordStriked.Add(new List<int>());
            coordStriked[j].Add(--x);
            coordStriked[j].Add(++y);
            c++;
        }
    }

    int[,] temp = new int[coordStriked.Count,2];
    for (int row = 0; row < coordStriked.Count; row++)
    {
        temp[row,0] = coordStriked[row][0];
        temp[row,1] = coordStriked[row][1];
    }
    for(int i = 0; i<coordStriked.Count; i++)
    {
        for(int j = 0; j<lim; j++)
            if(coord[j,0] == temp[i,0] && coord[j,1] == temp[i,1])
                strike = true; 
    }
    Console.WriteLine(strike==true?"Yes":"No");
    return temp;
}

PrintTable(fStrike(coord),coord);

