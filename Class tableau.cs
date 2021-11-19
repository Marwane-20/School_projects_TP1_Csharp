using System;
using System.Collections.Generic;
using System.Text;

namespace tabClass
{
    public class tableau
    {
        int mLength;
        string mType;
        int tmp;
        string tmp2;
        int[] mArr;
        string[] mArr2;
        int check;
        public tableau(int n, string type)                    // entrez "int" pour avoir tableau d'entier, ou "string" pour avoir tableau de string
        {
            this.mLength = n;
            this.mType = type;
            if (mType == "int")                             //Verififer si l'utilisateur a choisi int ou string
            {
                check = 1;
                mArr = new int[mLength];                //Variable qui est à 1 si "type == int", et à 2 si "type == string"
            }
            else if (mType == "string")                     // entrez "int" pour avoir tableau de string
            {
                check = 2;
                mArr2 = new string[mLength];
            }
        }
        public int MLength
        {
            get { return mLength; }
            set { mLength = value; }
        }
        public void fillTab()
        {
            if (check == 1)                                  // le tableau est de type " int "
            {
                Console.WriteLine("Entrez les valeurs de type int : ");
                int i;
                for (i = 0; i < MLength; i++)
                {
                    Console.WriteLine("Entrez la valeur {0}: ", i + 1);
                    mArr[i] = Convert.ToInt32(Console.ReadLine());
                }

            }
            if (check == 2)                                 // le tableau est de type " string "
            {
                Console.WriteLine("Entrez les valeurs de type string : ");
                int i;
                for (i = 0; i < MLength; i++)
                {
                    Console.WriteLine("Entrez la chaine {0}: ", i + 1);
                    mArr2[i] = Console.ReadLine();
                }
            }
        }
        public int findTab(int val)                      //retourne le nombre de fois la variable est présente dans le tableau
        {
            int temp = 0;

            for (int i = 0; i < MLength; i++)
            {
                if (val == mArr[i])
                {
                    temp++;
                }
            }
            return temp;
        }
        public int findTab(string val)
        {
            int temp = 0;
            for (int i = 0; i < MLength; i++)
            {
                if (string.Compare(val, mArr2[i]) == 0)
                {
                    temp++;
                }
            }
            return temp;
        }

        public void sort()
        {
            if (check == 1)
            {

                for (int i = 0; i < MLength; i++)
                {
                    for (int j = i + 1; j < MLength; j++)
                    {
                        if (mArr[j] < mArr[i])                         // ordre decroissant
                        {
                            tmp = mArr[i];
                            mArr[i] = mArr[j];
                            mArr[j] = tmp;
                        }
                    }
                }
            }
            else if (check == 2)
            {
                for (int i = 0; i < MLength; i++)
                {
                    string temp = mArr2[i];                                //le trie de la chaine suivant la premiere lettre du string
                    for (int j = i + 1; j < MLength; j++)
                    {
                        string temp2 = mArr2[j];
                        if (string.Compare(temp, temp2) == 1)              // comparer les deux premières lettres
                        {
                            tmp2 = mArr2[i];
                            mArr2[i] = mArr2[j];
                            mArr2[j] = tmp2;
                        }
                    }
                }
            }
        }
       
        public void revTab()                                //elle inverse un tableau
        {
            if (check == 1)
            {
                for (int i = 0, j = MLength - 1; i < MLength && j > i; i++, j--)  // j comment par le dernier element 
                {
                    tmp = mArr[i];                                                // variable qui stocke temporairement la valeur en i 
                    mArr[i] = mArr[j];                                            // on met la dernière valeur du tableau à la première position etc..
                    mArr[j] = tmp;
                }
            }
            if (check == 2)
            {
                for (int i = 0, j = MLength - 1; i < MLength && j > i; i++, j--)
                {
                    string temp = mArr2[i];
                    string temp2 = mArr2[j];
                    tmp2 = mArr2[i];
                    mArr2[i] = mArr2[j];
                    mArr2[j] = tmp2;
                }
            }
        }
        public void insert(int val)
        {
            int[] temp = new int[MLength + 1];                      //on crée un tableau tomporaire qui stocke les valeurs de mArr
            for (int i = 0; i < MLength; i++)
            {
                temp[i] = mArr[i];                                  // copie des valeurs en temp
            }
            mArr = new int[mLength + 1];                            // on crée le nouveau espace memoire pour mArr plus un emplacement pour inserer la valeure
            for (int i = 0; i < MLength; i++)
            {
                mArr[i] = temp[i];
            }
            mArr[MLength] = val;                                    // on ajout val à la dernière position
            MLength++;                                              // incrementation de la taile du tableau
        }   

        public void insert(string val)
        {
            string[] temp = new string[MLength + 1];
            for (int i = 0; i < MLength; i++)
            {
                    temp[i] = mArr2[i];
            }
            mArr2 = new string[MLength + 1];
            for (int i = 0; i < MLength; i++)
            {
                mArr2[i] = temp[i];
            }
            mArr2[MLength] = val;
            MLength++;
        }
        public void remove(int val)
        {
            int elements_Removed = 0;
            for(int i = 0;i < MLength; i++)
            {
                if (mArr[i] == val)
                {
                    elements_Removed += 1;                          // calcul le nombre d'elements supprimés
                    for (; i < MLength - 1; i++)                    
                    {
                        mArr[i] = mArr[i + 1];                      //deplacer les elements à gauche
                    }
                    i = 0;                                          //mettre i à 0 pour que la première boucle for commence de la position d'index 0 (debut)
                }
            }
            MLength -= elements_Removed;

        }
        public void remove(string val)
        {
            int elements_Removed = 0;
            for (int i = 0; i < MLength; i++)
            {
                if (string.Compare(val, mArr2[i]) == 0)
                {
                    elements_Removed += 1;
                    for (; i < MLength - 1; i++)
                    {
                        mArr2[i] = mArr2[i + 1];
                    }
                    i = 0;
                }
            }
            MLength -= elements_Removed;
        }
    }
        
}
