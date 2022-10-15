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

void PrintArray(int [] arr)
{
    Console.WriteLine();
    foreach(int i in arr)
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
int [] sumNumArr(int [] arr)
{
    int len = arr.Length;
    int [] arr1 = new int[len];
    for(int i = 0; i < len; i++)
        arr1[i] = sumNum(arr[i]);
    return arr1;
}
inputNum();
int a = int.Parse(Console.ReadLine());
inputNum("Введите степень, в которую нужно возвести число:");
int b = int.Parse(Console.ReadLine());
Console.WriteLine(Power(a,b));


inputNum();
int c = int.Parse(Console.ReadLine());
Console.Write(sumNum(c));

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
int [,] FillArraySpaces(int str, int cols)
{
    int counter = 0;
    string s;
    string[] subs;
    int [,] arr = new int [str, cols];
    Console.Write("Введите массив через пробел:");
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
int [,] coord = FillArraySpaces(8,2);
PrintIntMultiArr(coord);

void fStrike(int [,] coord)
{
    bool strike = false;
    int colString = coord.GetLength(0);
    int lim = 8;
    int [,] coordStriked = new int [colString*lim,2];
    int x,y;
    int rank = coord.Rank;
    int counter1 = 0;
    
    for(int i = 0; i<colString; i++)
    {
        x = coord[i,0];
        y = coord[i,1];
        for(int j = 0; j<colString; j++)
        {
            if(x == lim)
                break;
            coordStriked[j,0] = ++x;
            coordStriked[j,1] = ++y;
            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter1 ++;
        }
        Console.WriteLine();
        int counter2 = counter1;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter1; j<colString+counter1; j++)
        {
            if(y == lim)
                break;
            coordStriked[j,0] = x;
            coordStriked[j,1] = ++y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter2++;
        }
        Console.WriteLine();
        int counter3 = counter2;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter2; j<colString+counter2; j++)
        {
            if(x == lim)
                break;
            coordStriked[j,0] = ++x;
            coordStriked[j,1] = y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter3++;
        }
        Console.WriteLine();
        int counter4 = counter3;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter3; j<colString+counter3; j++)
        {
            if(x==lim || y == 1)
                break;
            coordStriked[j,0] = ++x;
            coordStriked[j,1] = --y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter4++;
        }
        Console.WriteLine();
        int counter5 = counter4;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter4; j<colString+counter4; j++)
        {
            if(y==1)
                break;
            coordStriked[j,0] = x;
            coordStriked[j,1] = --y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter5++;
        }
        Console.WriteLine();
        int counter6 = counter5;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter5; j<colString+counter5; j++)
        {
            if(x == 1 || y == 1)
                break;
            coordStriked[j,0] = --x;
            coordStriked[j,1] = --y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter6++;
        }

        Console.WriteLine();
        int counter7 = counter6;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter6; j<colString+counter6; j++)
        {
            if(x==1)
                break;
            coordStriked[j,0] = --x;
            coordStriked[j,1] = y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter7++;
        }
        Console.WriteLine();
        int counter8 = counter7;
        x = coord[i,0];
        y = coord[i,1];
        for(int j = counter7; j<colString+counter7; j++)
        {
            if(x==1 || y == lim)
                break;
            coordStriked[j,0] = --x;
            coordStriked[j,1] = ++y;

            Console.Write(" " + coordStriked[j,0]+ "," + coordStriked[j,1]);
            counter8++;
        }


    }
    for(int i = 0; i<colString*lim; i++)
    {
        for(int j = 0; j<colString; j++)
            if(coord[j,0] == coordStriked[i,0] && coord[j,1] == coordStriked[i,1])
                strike = true; 
    }
    Console.WriteLine(strike==true?"Yes":"No");
}
fStrike(coord);

