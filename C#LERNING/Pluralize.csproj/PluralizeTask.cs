namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            if (((count % 10 == 1) && (count < 100) && (count > 20)) || count == 1)
                return "рубль";
            else if ((count % 10 == 2) || (count % 10 == 3) || (count % 10 == 4) && (count > 20)) 
                return "рубля";
            else
                return "рублей";
        }
    }
}


/*
    Рубль   : 1,21,31,41,51,61,71,81,91,101,121,      a % 10 == 1    кроме 111, 1111    ||     if ( ( count % 10 == 1 ) && ( count % 100 != 11 ) ) 


    Рубля   : 2,3,4,22,23,24,32,33,34,42,43,44,                   if ( (count % 10 == 2) || (count % 10 == 3) || (count % 10 == 4) && ( count != 12 ) && ( count != 13 ) && ( count != 15 ) )


    Рублей  : 5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,35,36,37,38,39,40,  



    
    
    */
