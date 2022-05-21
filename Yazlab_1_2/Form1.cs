using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_1_2
{
   
    public partial class Form_Main : Form
    {
        
        public Form_Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        int[,] samuraiSudoku;

        int sudoku1KonumX = -1, sudoku1KonumY = -1;
        int sudoku2KonumX = -1, sudoku2KonumY = -1;
        int sudoku3KonumX = -1, sudoku3KonumY = -1;
        int sudoku4KonumX = -1, sudoku4KonumY = -1;
        int sudoku5KonumX = -1, sudoku5KonumY = -1;
        int sudoku1KonumX2 = -1, sudoku1KonumY2 = -1;
        int sudoku2KonumX2 = -1, sudoku2KonumY2 = -1;
        int sudoku3KonumX2 = -1, sudoku3KonumY2 = -1;
        int sudoku4KonumX2 = -1, sudoku4KonumY2 = -1;
        int sudoku5KonumX2 = -1, sudoku5KonumY2 = -1;

        FileStream dosya,dosyaYaz;
        StreamWriter yaz;
        Thread t1, t2, t3, t4, t5, t6, t7, t8, t9, t10;

        bool altSudokuKontrol(int sudokuIndex)
        {
            // sudokunun tamamlanıp tamamlanmadiğini kontrol eder
            if (sudokuIndex == 0)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        if (samuraiSudoku[i, j] == 0)
                            return false;
            }
            else if (sudokuIndex == 1)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 12; j < 21; j++)
                        if (samuraiSudoku[i, j] == 0)
                            return false;
            }
            else if (sudokuIndex == 2)
            {
                for (int i = 12; i < 21; i++)
                    for (int j = 0; j < 9; j++)
                        if (samuraiSudoku[i, j] == 0)
                            return false;
            }
            else if (sudokuIndex == 3)
            {
                for (int i = 12; i < 21; i++)
                    for (int j = 12; j < 21; j++)
                        if (samuraiSudoku[i, j] == 0)
                            return false;
            }
            else if (sudokuIndex == 4)
            {
                for (int i = 6; i < 15; i++)
                    for (int j = 6; j < 15; j++)
                        if (samuraiSudoku[i, j] == 0)
                            return false;
            }
            return true;
        }

        int[] blokIcıkonumdanSudokuIcıKonumBul(int sudokuIndex, int blokIndex, int konumX, int konumY)
        {
            int[] konum = new int[2];

            if (sudokuIndex == 0)
            {
                if (blokIndex == 0) { konum[0] = konumX; konum[1] = konumY; }
                else if (blokIndex == 1) { konum[0] = konumX; konum[1] = konumY + 3; }
                else if (blokIndex == 2) { konum[0] = konumX; konum[1] = konumY + 6; }
                else if (blokIndex == 3) { konum[0] = konumX + 3; konum[1] = konumY; }
                else if (blokIndex == 4) { konum[0] = konumX + 3; konum[1] = konumY + 3; }
                else if (blokIndex == 5) { konum[0] = konumX + 3; konum[1] = konumY + 6; }
                else if (blokIndex == 6) { konum[0] = konumX + 6; konum[1] = konumY; }
                else if (blokIndex == 7) { konum[0] = konumX + 6; konum[1] = konumY + 3; }
                else if (blokIndex == 8) { konum[0] = konumX + 6; konum[1] = konumY + 6; }
            }
            else if (sudokuIndex == 1)
            {
                if (blokIndex == 0) { konum[0] = konumX; konum[1] = konumY + 12; }
                else if (blokIndex == 1) { konum[0] = konumX; konum[1] = konumY + 15; }
                else if (blokIndex == 2) { konum[0] = konumX; konum[1] = konumY + 18; }
                else if (blokIndex == 3) { konum[0] = konumX + 3; konum[1] = konumY + 12; }
                else if (blokIndex == 4) { konum[0] = konumX + 3; konum[1] = konumY + 15; }
                else if (blokIndex == 5) { konum[0] = konumX + 3; konum[1] = konumY + 18; }
                else if (blokIndex == 6) { konum[0] = konumX + 6; konum[1] = konumY + 12; }
                else if (blokIndex == 7) { konum[0] = konumX + 6; konum[1] = konumY + 15; }
                else if (blokIndex == 8) { konum[0] = konumX + 6; konum[1] = konumY + 18; }
            }
            if (sudokuIndex == 2)
            {
                if (blokIndex == 0) { konum[0] = konumX + 12; konum[1] = konumY; }
                else if (blokIndex == 1) { konum[0] = konumX + 12; konum[1] = konumY + 3; }
                else if (blokIndex == 2) { konum[0] = konumX + 12; konum[1] = konumY + 6; }
                else if (blokIndex == 3) { konum[0] = konumX + 15; konum[1] = konumY; }
                else if (blokIndex == 4) { konum[0] = konumX + 15; konum[1] = konumY + 3; }
                else if (blokIndex == 5) { konum[0] = konumX + 15; konum[1] = konumY + 6; }
                else if (blokIndex == 6) { konum[0] = konumX + 18; konum[1] = konumY; }
                else if (blokIndex == 7) { konum[0] = konumX + 18; konum[1] = konumY + 3; }
                else if (blokIndex == 8) { konum[0] = konumX + 18; konum[1] = konumY + 6; }
            }
            if (sudokuIndex == 3)
            {
                if (blokIndex == 0) { konum[0] = konumX + 12; konum[1] = konumY + 12; }
                else if (blokIndex == 1) { konum[0] = konumX + 12; konum[1] = konumY + 15; }
                else if (blokIndex == 2) { konum[0] = konumX + 12; konum[1] = konumY + 18; }
                else if (blokIndex == 3) { konum[0] = konumX + 15; konum[1] = konumY + 12; }
                else if (blokIndex == 4) { konum[0] = konumX + 15; konum[1] = konumY + 15; }
                else if (blokIndex == 5) { konum[0] = konumX + 15; konum[1] = konumY + 18; }
                else if (blokIndex == 6) { konum[0] = konumX + 18; konum[1] = konumY + 12; }
                else if (blokIndex == 7) { konum[0] = konumX + 18; konum[1] = konumY + 15; }
                else if (blokIndex == 8) { konum[0] = konumX + 18; konum[1] = konumY + 18; }
            }
            if (sudokuIndex == 4)
            {
                if (blokIndex == 0) { konum[0] = konumX + 6; konum[1] = konumY + 6; }
                else if (blokIndex == 1) { konum[0] = konumX + 6; konum[1] = konumY + 9; }
                else if (blokIndex == 2) { konum[0] = konumX + 6; konum[1] = konumY + 12; }
                else if (blokIndex == 3) { konum[0] = konumX + 9; konum[1] = konumY + 6; }
                else if (blokIndex == 4) { konum[0] = konumX + 9; konum[1] = konumY + 9; }
                else if (blokIndex == 5) { konum[0] = konumX + 9; konum[1] = konumY + 12; }
                else if (blokIndex == 6) { konum[0] = konumX + 12; konum[1] = konumY + 6; }
                else if (blokIndex == 7) { konum[0] = konumX + 12; konum[1] = konumY + 9; }
                else if (blokIndex == 8) { konum[0] = konumX + 12; konum[1] = konumY + 12; }
            }


            return konum;
        }

        int[] yeniBlokSec(int sudokuIndex)
        {
            int[] yeniKonum = new int[2];

            List<int[,]> bloklar = new List<int[,]>();
            //if (sudoku[x + ((b / 3) * 3), y + ((b % 3) * 3)] != 0)
            for (int b = 0; b < 9; b++)
            {
                int[,] blok = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sudokuIndex == 0)
                        {
                            blok[i, j] = samuraiSudoku[(i + 0) + ((b / 3) * 3), (j + 0) + ((b % 3) * 3)];
                        }
                        else if (sudokuIndex == 1)
                        {
                            blok[i, j] = samuraiSudoku[(i + 0) + ((b / 3) * 3), (j + 12) + ((b % 3) * 3)];
                        }
                        else if (sudokuIndex == 2)
                        {
                            blok[i, j] = samuraiSudoku[(i + 12) + ((b / 3) * 3), (j + 0) + ((b % 3) * 3)];
                        }
                        else if (sudokuIndex == 3)
                        {
                            blok[i, j] = samuraiSudoku[(i + 12) + ((b / 3) * 3), (j + 12) + ((b % 3) * 3)];
                        }
                        else if (sudokuIndex == 4)
                        {
                            blok[i, j] = samuraiSudoku[(i + 6) + ((b / 3) * 3), (j + 6) + ((b % 3) * 3)];
                        }

                    }
                }
                bloklar.Add(blok);
            }

            List<int> blokDoluHücreSayisi = new List<int>();
            //int[] blokId = new int[bloklar.Count];
            for (int i = 0; i < bloklar.Count; i++)
            {
                int blokDoluHücreSaysi = 0;
                for (int x = 0; x < 3; x++)
                    for (int y = 0; y < 3; y++)
                        if (bloklar[i][x, y] != 0)
                            blokDoluHücreSaysi++;
                blokDoluHücreSayisi.Add(blokDoluHücreSaysi);
                /*
                if (blokDoluHücreSaysi != 9)
                {
                    //blokId[i] = i;
                    blokDoluHücreSayisi.Add(blokDoluHücreSaysi);
                }
                */
            }
            int enDoluHücreIndex = 0;
            for (int i = 8; i > -1; i--)
            {
                if (blokDoluHücreSayisi.Contains(i))
                {
                    enDoluHücreIndex = blokDoluHücreSayisi.IndexOf(i);
                    break;
                }


            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (bloklar[enDoluHücreIndex][i, j] == 0)
                    {
                        yeniKonum = blokIcıkonumdanSudokuIcıKonumBul(sudokuIndex, enDoluHücreIndex, i, j);
                        return yeniKonum;
                    }

            return yeniKonum;
        }

        bool tekrarKontrol(List<int> liste)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == j)
                        continue;
                    else if (liste[i] == 0)
                        continue;
                    else if (liste[i] == liste[j])
                        return false;
                }
            }
            return true;
        }

        bool yeniBlokKontrol(int konumX, int konumY)
        {
            //int[] blokSatir = new int[9];

            List<int> BlokSatir = new List<int>();
            // sol üst sudoku



            if (konumX < 9 && konumY < 9)
            {
                // sol üst
                if (konumX < 3 && konumY < 3)
                {
                    // 0. blok

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 0]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 3 && konumY < 6)
                {
                    // 1. blok

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 3]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);

                }
                else if (konumX < 3 && konumY < 9)
                {
                    // 2. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 6 && konumY < 3)
                {
                    // 3. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 3, j + 0]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 6 && konumY < 6)
                {
                    // 4. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 3, j + 3]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 6 && konumY < 9)
                {
                    // 5. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 3, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 3)
                {
                    // 6. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 0]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 6)
                {
                    // 7. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 3]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 9)
                {
                    // 8. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
            }

            else if (konumX < 9 && konumY > 11 && konumY < 21)
            {
                // sağ üst

                if (konumX < 3 && konumY < 15)
                {
                    // 0. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 3 && konumY < 18)
                {
                    // 1. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 15]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 3 && konumY < 21)
                {
                    // 2. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 18]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 6 && konumY < 15)
                {
                    // 3. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 3, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 6 && konumY < 18)
                {
                    // 4. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 3, j + 15]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 6 && konumY < 21)
                {
                    // 5. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 3, j + 18]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 15)
                {
                    // 6. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 18)
                {
                    // 7. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 15]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 21)
                {
                    // 8. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 0, j + 18]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
            }
            else if (konumX > 11 && konumX < 21 && konumY < 9)
            {
                // sol alt

                if (konumX < 15 && konumY < 3)
                {
                    // 0. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 0]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 6)
                {
                    // 1. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 3]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 9)
                {
                    // 2. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 18 && konumY < 3)
                {
                    // 3. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 15, j + 0]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 18 && konumY < 6)
                {
                    // 4. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 15, j + 3]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 18 && konumY < 9)
                {
                    // 5. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 15, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 21 && konumY < 3)
                {
                    // 6. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 18, j + 0]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 21 && konumY < 6)
                {
                    // 7. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 18, j + 3]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 21 && konumY < 9)
                {
                    // 8. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 18, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
            }
            else if (konumX > 11 && konumX < 21 && konumY > 11 && konumY < 21)
            {
                // sağ alt

                if (konumX < 15 && konumY < 15)
                {
                    // 0. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 18)
                {
                    // 1. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 15]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 21)
                {
                    // 2. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 18]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 18 && konumY < 15)
                {
                    // 3. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 15, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 18 && konumY < 18)
                {
                    // 4. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 15, j + 15]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 18 && konumY < 21)
                {
                    // 5. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 15, j + 18]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 21 && konumY < 15)
                {
                    // 6. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 18, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 21 && konumY < 18)
                {
                    // 7. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 18, j + 15]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 21 && konumY < 21)
                {
                    // 8. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 18, j + 18]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
            }
            else if (konumX > 5 && konumX < 15 && konumY > 5 && konumY < 15)
            {
                // orta

                if (konumX < 9 && konumY < 9)
                {
                    // 0. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 12)
                {
                    // 1. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 9]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 9 && konumY < 15)
                {
                    // 2. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 6, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 12 && konumY < 9)
                {
                    // 3. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 9, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 12 && konumY < 12)
                {
                    // 4. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 9, j + 9]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 12 && konumY < 15)
                {
                    // 5. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 9, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 9)
                {
                    // 6. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 6]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 12)
                {
                    // 7. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 9]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
                else if (konumX < 15 && konumY < 15)
                {
                    // 8. blok
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BlokSatir.Add(samuraiSudoku[i + 12, j + 12]);
                        }
                    }
                    return tekrarKontrol(BlokSatir);
                }
            }
            return false;
        }

        bool yeniSatirKontrol(int konumX, int konumY)
        {

            List<int> Satir = new List<int>();
            List<int> SatirKesisim = new List<int>();

            if (konumX < 6)
            {
                // sudoku 1 ve sudoku 2 kesişmeyen kısım
                if (konumY < 9)
                {
                    // sudoku 1
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i]);
                }
                else
                {
                    // sudoku 2
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i + 12]);
                }
            }
            else if (konumX < 9)
            {
                // sudoku 1 sudoku 2 ve sudoku 5 kesisim yeri
                if (konumY < 6)
                {
                    // sudoku 1
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i]);

                }
                else if (konumY < 9)
                {
                    // sudoku 1 ve sudoku 5 kesisim
                    //satirKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Satir.Add(samuraiSudoku[konumX, i]);
                        SatirKesisim.Add(samuraiSudoku[konumX, i + 6]);
                    }
                }
                else if (konumY < 12)
                {
                    // sudoku 5
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i + 6]);
                }
                else if (konumY < 15)
                {
                    // sudoku 5 ve sudoku 2
                    //satirKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Satir.Add(samuraiSudoku[konumX, i + 6]);
                        SatirKesisim.Add(samuraiSudoku[konumX, i + 12]);
                    }
                }
                else if (konumY < 21)
                {
                    // sudoku 2
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i + 12]);
                }
            }
            else if (konumX < 12)
            {
                // sudoku 5
                for (int i = 0; i < 9; i++)
                    Satir.Add(samuraiSudoku[konumX, i + 6]);
            }
            else if (konumX < 15)
            {
                // sudoku 3 sudoku 5 ve sudoku 4 kesişim
                if (konumY < 6)
                {
                    // sudoku 3
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i]);

                }
                else if (konumY < 9)
                {
                    // sudoku 3 ve sudoku 5 kesisim
                    //satirKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Satir.Add(samuraiSudoku[konumX, i]);
                        SatirKesisim.Add(samuraiSudoku[konumX, i + 6]);
                    }
                }
                else if (konumY < 12)
                {
                    // sudoku 5
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i + 6]);
                }
                else if (konumY < 15)
                {
                    // sudoku 5 ve sudoku 4
                    //satirKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Satir.Add(samuraiSudoku[konumX, i + 6]);
                        SatirKesisim.Add(samuraiSudoku[konumX, i + 12]);
                    }
                }
                else if (konumY < 21)
                {
                    // sudoku 4
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i + 12]);
                }
            }
            else if (konumX < 21)
            {
                // sudoku 3 ve sudoku 4 kesişim olmaayan yer
                if (konumY < 9)
                {
                    // sudoku 3
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i]);
                }
                else
                {
                    // sudoku 4
                    for (int i = 0; i < 9; i++)
                        Satir.Add(samuraiSudoku[konumX, i + 12]);
                }
            }


            if (SatirKesisim.Count != 0)
            {

                if (tekrarKontrol(Satir) && tekrarKontrol(SatirKesisim))
                    return true;
                else
                    return false;

            }
            else
            {
                return tekrarKontrol(Satir);
            }

        }

        bool yeniSutunKontrol(int konumX, int konumY)
        {

            List<int> Sutun = new List<int>();
            List<int> SutunKesisimi = new List<int>();


            if (konumY < 6)
            {
                // sudoku 1 ve sudoku 3 kesişmeyen kısım
                if (konumX < 9)
                {
                    // sudoku 1
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i, konumY]);
                }
                else
                {
                    // sudoku 3
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i + 12, konumY]);
                }
            }
            else if (konumY < 9)
            {
                // sudoku 1 sudoku 5 ve sudoku 3 kesisim yeri
                if (konumX < 6)
                {
                    // sudoku 1
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i, konumY]);

                }
                else if (konumX < 9)
                {
                    // sudoku 1 ve sudoku 5 kesisim
                    //sutunKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Sutun.Add(samuraiSudoku[i, konumY]);
                        SutunKesisimi.Add(samuraiSudoku[i + 6, konumY]);
                    }
                }
                else if (konumX < 12)
                {
                    // sudoku 5
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i + 6, konumY]);
                }
                else if (konumX < 15)
                {
                    // sudoku 5 ve sudoku 3
                    //sutunKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Sutun.Add(samuraiSudoku[i + 6, konumY]);
                        SutunKesisimi.Add(samuraiSudoku[i + 12, konumY]);
                    }
                }
                else if (konumX < 21)
                {
                    // sudoku 3
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i + 12, konumY]);
                }
            }
            else if (konumY < 12)
            {
                // sudoku 5
                for (int i = 0; i < 9; i++)
                    Sutun.Add(samuraiSudoku[i + 6, konumY]);
            }
            else if (konumY < 15)
            {
                // sudoku 2 sudoku 5 ve sudoku 4 kesişim
                if (konumX < 6)
                {
                    // sudoku 2
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i, konumY]);

                }
                else if (konumX < 9)
                {
                    // sudoku 3 ve sudoku 5 kesisim
                    //sutunKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Sutun.Add(samuraiSudoku[i, konumY]);
                        SutunKesisimi.Add(samuraiSudoku[i + 6, konumY]);
                    }
                }
                else if (konumX < 12)
                {
                    // sudoku 5
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i + 6, konumY]);
                }
                else if (konumX < 15)
                {
                    // sudoku 5 ve sudoku 4
                    //sutunKesisim1 = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        Sutun.Add(samuraiSudoku[i + 6, konumY]);
                        SutunKesisimi.Add(samuraiSudoku[i + 12, konumY]);
                    }
                }
                else if (konumX < 21)
                {
                    // sudoku 4
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i + 12, konumY]);
                }
            }
            else if (konumY < 21)
            {
                // sudoku 2 ve sudoku 4 kesişim olmaayan yer
                if (konumX < 9)
                {
                    // sudoku 2
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i, konumY]);
                }
                else
                {
                    // sudoku 4
                    for (int i = 0; i < 9; i++)
                        Sutun.Add(samuraiSudoku[i + 12, konumY]);
                }
            }

            if (SutunKesisimi.Count != 0)
            {

                if (tekrarKontrol(Sutun) && tekrarKontrol(SutunKesisimi))
                    return true;
                else
                    return false;

            }
            else
            {
                return tekrarKontrol(Sutun);
            }

        }

        List<int> hucreyeUygunRakamlar(int konumX, int konumY)
        {
            List<int> rakamlar = new List<int>();

            for (int i = 1; i <= 9; i++)
            {

                //((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).Text = i.ToString();
                //Thread.Sleep(10);

                samuraiSudoku[konumX, konumY] = i;

                if (yeniBlokKontrol(konumX, konumY) && yeniSatirKontrol(konumX, konumY) && yeniSutunKontrol(konumX, konumY))
                {
                    rakamlar.Add(i);
                }
                samuraiSudoku[konumX, konumY] = 0;
            }

            return rakamlar;
        }


        private void sudokuCoz(int sudokuIndex, int konumX, int konumY, string threadAdi)
        {
            // samurai sudoku tamamlanmadığı sürece dön
            while (!altSudokuKontrol(sudokuIndex))
            {
                if (samuraiSudoku[konumX, konumY] != 0)
                {
                    // hücre dolu yeni konum seç

                    int[] sonrakiKonum = yeniBlokSec(sudokuIndex); //yeniKonumBul(sudokuIndex, konumX, konumY); //yeniBlokSec(sudokuIndex);
                    sudokuCoz(sudokuIndex, sonrakiKonum[0], sonrakiKonum[1], threadAdi);

                    return;
                }

                // verilen konuma rakam koy ve kontrol et

                //((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.AliceBlue;
                //Thread.Sleep(10);

                List<int> uygunRakamlar = hucreyeUygunRakamlar(konumX, konumY);
                if (uygunRakamlar.Count == 0)
                {
                    // hücreye uygun hiç rakam yok
                    return;
                }
                else
                {
                    try
                    {
                        string hamle = "";
                        //int listboxIndex = -1;
                        for (int i = 0; i < uygunRakamlar.Count; i++)
                        {
                            samuraiSudoku[konumX, konumY] = uygunRakamlar[i];
                            hamle = threadAdi + " adli thread (" + konumX.ToString() + "," + konumY.ToString() + ") konumuna " + uygunRakamlar[i].ToString() + " rakamini ekledi.";
                            listBox_hamleler.Items.Add(hamle);
                            yaz.WriteLine(hamle);
                            //listboxKaydir();
                            //listboxIndex = listBoxHamleler.Items.Count - 1;

                            ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).Text = uygunRakamlar[i].ToString();
                            if (sudokuIndex == 0)
                                ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.LightGreen;
                            else if (sudokuIndex == 1)
                                ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.LightBlue;
                            else if (sudokuIndex == 2)
                                ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.OrangeRed;
                            else if (sudokuIndex == 3)
                                ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.Lime;
                            else if (sudokuIndex == 4)
                                ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.Fuchsia;

                            //Thread.Sleep(10);

                            // konum seçme kodları
                            int[] sonrakiKonum = yeniBlokSec(sudokuIndex); //yeniKonumBul(sudokuIndex, konumX, konumY); //yeniBlokSec(sudokuIndex);
                            sudokuCoz(sudokuIndex, sonrakiKonum[0], sonrakiKonum[1], threadAdi);

                            // eğer seçilen yerden geri dönülmüşse
                            if (altSudokuKontrol(sudokuIndex))
                            {
                                // sudoku tamamlanmışsa çık
                                return;
                            }

                        }

                    // tüm rakamlar olmadıysa geri dön
                    //((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.LightPink;

                        ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).Text = "";
                        ((Label)(Controls.Find("label_" + konumX.ToString() + "_" + konumY.ToString(), true)[0])).BackColor = Color.FromArgb(253, 253, 253);
                        //Thread.Sleep(10);
                        samuraiSudoku[konumX, konumY] = 0;
                        /*
                        if (listBox_hamleler.Items.Contains(hamle) && hamle != null)
                        {
                            listBox_hamleler.Items.Remove(hamle);

                        }*/
                        //listboxKaydir();
                        return;
                    }
                    catch (Exception e)
                    {

                    }

                }

            }
            return;
        }

        private void button_10_threadli_Click(object sender, EventArgs e)
        {
            dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\10threadli.txt", FileMode.OpenOrCreate, FileAccess.Write);
            yaz = new StreamWriter(dosyaYaz);

            t5 = new Thread(new ThreadStart(() => sudokuCoz(4, sudoku5KonumX, sudoku5KonumY, "Thread 5")));
            t5.Start();

            t10 = new Thread(new ThreadStart(() => sudokuCoz(4, sudoku5KonumX2, sudoku5KonumY2, "Thread 10")));
            t10.Start();
            t10.Join();
            //t5.Join();
            t1 = new Thread(new ThreadStart(() => sudokuCoz(0, sudoku1KonumX, sudoku1KonumY, "Thread 1")));
            t1.Start();

            t2 = new Thread(new ThreadStart(() => sudokuCoz(1, sudoku2KonumX, sudoku2KonumY, "Thread 2")));
            t2.Start();

            t3 = new Thread(new ThreadStart(() => sudokuCoz(2, sudoku3KonumX, sudoku3KonumY, "Thread 3")));
            t3.Start();

            t4 = new Thread(new ThreadStart(() => sudokuCoz(3, sudoku4KonumX, sudoku4KonumY, "Thread 4")));
            t4.Start();


            t6 = new Thread(new ThreadStart(() => sudokuCoz(0, sudoku1KonumX2, sudoku1KonumY2, "Thread 6")));
            t6.Start();

            t7 = new Thread(new ThreadStart(() => sudokuCoz(1, sudoku2KonumX2, sudoku2KonumY2, "Thread 7")));
            t7.Start();

            t8 = new Thread(new ThreadStart(() => sudokuCoz(2, sudoku3KonumX2, sudoku3KonumY2, "Thread 8")));
            t8.Start();

            t9 = new Thread(new ThreadStart(() => sudokuCoz(3, sudoku4KonumX2, sudoku4KonumY2, "Thread 9")));
            t9.Start();
        }

        private void button_5_threadli_Click(object sender, EventArgs e)
        {
            dosyaYaz = new FileStream(Application.StartupPath.ToString() + "\\5threadli.txt", FileMode.OpenOrCreate, FileAccess.Write);
            yaz = new StreamWriter(dosyaYaz);
            t5 = new Thread(new ThreadStart(() => sudokuCoz(4, sudoku5KonumX, sudoku5KonumY, "Thread 5")));
            t5.Start();
            t5.Join();

            t1 = new Thread(new ThreadStart(() => sudokuCoz(0, sudoku1KonumX, sudoku1KonumY, "Thread 1")));
            t1.Start();

            t2 = new Thread(new ThreadStart(() => sudokuCoz(1, sudoku2KonumX, sudoku2KonumY, "Thread 2")));
            t2.Start();

            t3 = new Thread(new ThreadStart(() => sudokuCoz(2, sudoku3KonumX, sudoku3KonumY, "Thread 3")));
            t3.Start();

            t4 = new Thread(new ThreadStart(() => sudokuCoz(3, sudoku4KonumX, sudoku4KonumY, "Thread 4")));
            t4.Start();
        }

        

        private void label_Yerlestir()
        {
            //Controls.Clear();

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    if ((i < 6 || i > 14) && (j > 8 && j < 12))
                        continue;
                    else if ((j < 6 || j > 14) && (i > 8 && i < 12))
                        continue;
                    Label label = new Label();
                    label.Parent = this;
                    label.Margin = new Padding(0);
                    label.BackColor = Color.FromArgb(253, 253, 253);
                    label.Name = "label_" + i.ToString() + "_" + j.ToString();
                    label.Text = "";
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Anchor = AnchorStyles.None;
                    label.Size = new Size(30, 30);
                    label.AutoSize = false;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    //label.Click += labelIsıimGoster;

                    if (i < 9 && j < 9)
                    {
                        label.Location = new Point(12 + (j * 30), 12 + (i * 30));
                        Controls.Add(label);
                        //MessageBox.Show(label.Name);
                    }
                    else if (i < 9 && j > 11)
                    {
                        label.Location = new Point(372 + ((j - 12) * 30), 12 + (i * 30));
                        Controls.Add(label);
                        //MessageBox.Show(label.Name);
                    }
                    else if (i > 11 && j < 9)
                    {
                        label.Location = new Point(12 + (j * 30), 372 + ((i - 12) * 30));
                        Controls.Add(label);
                    }
                    else if (i > 11 && j > 11)
                    {
                        label.Location = new Point(372 + ((j - 12) * 30), 372 + ((i - 12) * 30));
                        Controls.Add(label);
                        //MessageBox.Show(label.Name);
                    }
                    else if (i > 5 && i < 15 && j > 5 && j < 15)
                    {
                        label.Location = new Point(192 + ((j - 6) * 30), 192 + ((i - 6) * 30));
                        Controls.Add(label);
                    }
                }
            }
        }

        private void sudokuOlustur()
        {
            string dosyaYeri = Application.StartupPath + "\\sudoku.txt";
            FileStream dosya = new FileStream(dosyaYeri, FileMode.Open, FileAccess.Read);
            StreamReader oku = new StreamReader(dosya);
            string satir = oku.ReadLine();
            int satirSayisi = 0;
            while (satir != null)
            {
                for (int i = 0; i < satir.Length; i++)
                {

                    // karakter bir sayi ise
                    if (Char.IsNumber(satir[i]))
                    {

                        if (satir.Length == 18)
                        {
                            // köşelerdeki sudokuların kesişim olmayan yeri
                            samuraiSudoku[satirSayisi, (i < 9) ? i : i + 3] = Convert.ToInt32(satir[i].ToString());
                            ((Label)(Controls.Find("label_" + satirSayisi.ToString() + "_" + (i < 9 ? i : i + 3).ToString(), true)[0])).Text = satir[i].ToString();

                        }
                        else if (satir.Length == 21)
                        {
                            // ortadaki sudokunun köşelerdeki sudokuyla kesişim olan yeri
                            samuraiSudoku[satirSayisi, i] = Convert.ToInt32(satir[i].ToString());
                            ((Label)(Controls.Find("label_" + satirSayisi.ToString() + "_" + i.ToString(), true)[0])).Text = satir[i].ToString();
                        }
                        else if (satir.Length == 9)
                        {
                            // ortakadi sudokunun kesişim olmayan yeri
                            samuraiSudoku[satirSayisi, i + 6] = Convert.ToInt32(satir[i].ToString());
                            ((Label)(Controls.Find("label_" + satirSayisi.ToString() + "_" + (i + 6).ToString(), true)[0])).Text = satir[i].ToString();
                        }

                    }
                }
                satir = oku.ReadLine();
                satirSayisi++;
            }
        }

        bool sudokuKontrol()
        {
            // sudokunun tamamlanıp tamamlanmadiğini kontrol eder
            for (int i = 0; i < 21; i++)
                for (int j = 0; j < 21; j++)
                    if (samuraiSudoku[i, j] == 0)
                        return false;
            return true;
        }

        void konumlariOku()
        {
            dosya = new FileStream(Application.StartupPath.ToString() + "\\konumlar.txt", FileMode.Open, FileAccess.Read);
            StreamReader oku = new StreamReader(dosya);
            string satir;
            do
            {
                satir = oku.ReadLine();
                if (sudoku1KonumX == -1 && sudoku1KonumY == -1)
                {
                    sudoku1KonumX = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku1KonumY = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku2KonumX == -1 && sudoku2KonumY == -1)
                {
                    sudoku2KonumX = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku2KonumY = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku3KonumX == -1 && sudoku3KonumY == -1)
                {
                    sudoku3KonumX = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku3KonumY = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku4KonumX == -1 && sudoku4KonumY == -1)
                {
                    sudoku4KonumX = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku4KonumY = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku5KonumX == -1 && sudoku5KonumY == -1)
                {
                    sudoku5KonumX = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku5KonumY = Convert.ToInt32(satir.Split(',')[1].Trim());
                }

                else if (sudoku1KonumX2 == -1 && sudoku1KonumY2 == -1)
                {
                    sudoku1KonumX2 = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku1KonumY2 = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku2KonumX2 == -1 && sudoku2KonumY2 == -1)
                {
                    sudoku2KonumX2 = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku2KonumY2 = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku3KonumX2 == -1 && sudoku3KonumY2 == -1)
                {
                    sudoku3KonumX2 = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku3KonumY2 = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku4KonumX2 == -1 && sudoku4KonumY2 == -1)
                {
                    sudoku4KonumX2 = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku4KonumY2 = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
                else if (sudoku5KonumX2 == -1 && sudoku5KonumY2 == -1)
                {
                    sudoku5KonumX2 = Convert.ToInt32(satir.Split(',')[0].Trim());
                    sudoku5KonumY2 = Convert.ToInt32(satir.Split(',')[1].Trim());
                }
            } while (satir != null);
        }

        void ciz(string threadSaysisi)
        {
            
        }
        
        


        private void Form_Main_Load(object sender, EventArgs e)
        {
            
            label_Yerlestir();
            samuraiSudoku = new int[21, 21];
            // sudoku matrisini doldur
            for (int i = 0; i < 21; i++)
                for (int j = 0; j < 21; j++)
                {
                    // sudokuda olmayan indexleri -1 kalanını 0 yap
                    if ((i < 6 || i > 14) && (j > 8 && j < 12))
                        samuraiSudoku[i, j] = -1;
                    else if ((j < 6 || j > 14) && (i > 8 && i < 12))
                        samuraiSudoku[i, j] = -1;
                    else
                        samuraiSudoku[i, j] = 0;
                }

            sudokuOlustur();
            konumlariOku();
        }
    }
}
