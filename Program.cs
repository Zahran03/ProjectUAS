using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    { 
        //pendefinisian 3 array variabel dan 5 variabel penunjang supaya applikasi berjalan dengan semestinya
        //variabel Array NamaBarang akan berisi nama2 barang yang ingin user beli, Variabel array HargaSatuan
        //menyimpan Harga satuan dari barang yang ingin user beli, Variabel Jumlah Barang menampung jumlah
        //barang yang ingin dibeli user
        string[] NamaBarang= new string[100]; 
        int[] HargaSatuan = new int[100]; 
        int[] JumlahBarang = new int[100];
        //Varibel IndexSekarang akan terisi ketika user ingin menambah barang atau tidak
        int IndexSekarang = 0;
        //Variabel Uang akan terisi ketika melakukan pembayaran
        int Uang = 0;
        //Varibel Kembalian akan terisi Ketika Uang yang dibayarkan lebih dari total Belanja 
        int Kembalian = 0;
        //Variabel Total Belanja akan terisi ketika semua ketika selesai memilih barang apa 
        //saja yang ingin dibeli
        int TotalBelanja = 0;
        string Keputusan ;
        while (true)
        {
            //blok try code berfungsi mendekteksi bila ada kesalahan input saat proses belanja
            //mengapa menggunakan try karna apabila ada error kode tidak langsung selesai
            //program akan memberitahu kesalahan apa yang membuat kode Error
            try
            {
                //kode di blok While loop,  berfungsi untuk menginputkan nama barang yang 
                //ingin dibeli, harga satuan nya, jumlah barang. Setiap Selesai menginputkan
                //nama barang, harga satuan, dan jumlah barang. program akan bertanya 
                //ingin menambah barang atau tidak , kalo iya user aka menginputkan lagi 
                //nama barang, harga, dan jumlah barang lagi, dan program di blok While ini baru
                //berhenti ketika user menginputkan "N" saat ditanya oleh program ingin menambah
                //barang atau tidak
                Console.WriteLine("Masukan nama Barang yang anda ingin beli");
                //Kode dibawah berfungsi untuk menginput nama barang dan di simpan
                //di array NamaBarng
                NamaBarang[IndexSekarang] = Console.ReadLine();
                HargaSatuan:
                //Kode dibawah berfungsi untuk menginput harga satuan dan di simpan
                //di array HargaSatuan
                Console.WriteLine("Masukan harga satuan barang yang anda beli");
                HargaSatuan[IndexSekarang] = Int32.Parse(Console.ReadLine());
                //Harga Satuan Barang nilai nya tidak boleh mines
                if (HargaSatuan[IndexSekarang] < 0)
                {
                    Console.WriteLine("Maaf Harga barang tidak boleh Mines");
                    goto HargaSatuan;
                }
                Console.WriteLine("Masukan jumlah Barang nya");
                //Kode dibawah berfungsi untuk menginput jumlah barang dan di simpan
                //di array JumlahBarang
                JumlahBarang[IndexSekarang] = Int32.Parse(Console.ReadLine());
                //Variabel TotalBelanja akan diisi HargaSatuan Yang dikali dengan Variabel JumlahBarang
                TotalBelanja += HargaSatuan[IndexSekarang] * JumlahBarang[IndexSekarang];
                Console.WriteLine("Apakah kamu mau menambah barang yang ingin kamu beli (Y/T)");
                string Jawaban = Console.ReadLine().ToUpper();
                // Variabel IndexSekarang akan bertambah ketika user ingin menambah barang dan IndexSekarang 
                //berfungsi sebagai index untuk variabel yang bertipe array
                IndexSekarang++;
                if (Jawaban == "T")
                {
                    break;
                } 
            //Catch Berfungsi untuk mendeteksi Error ketika proses Menginputkan barang yang akan dibeli
            //dan akan menampilkan pesan error nya di CMD jadi tidak langsung keluar dari program ketika
            //error
            } catch (Exception e)
            {
                Console.WriteLine("Kesalahan Terjadi Karena : " + e.Message);
            }
        }
        //Kode dibawah ini akan menjalankan proses pembayaran, diantaranya ada proses total belanjaan,
        //kembalian, dan menginputkan nominal uang yang
        //ditentukan oleh variabel totalBelanja
        Console.WriteLine("Total Belanjaan Anda Sebesar : " + TotalBelanja);
        InputUang:
        Console.WriteLine("Masukan Jumlah Uang yang Harus dibayarkan ");
        //Proses input Uang yang harus dibayar ke Variabel Uang
        Uang = Int32.Parse(Console.ReadLine());
        //pengkondisian ketika uang yang diibayarkan kurang menampilakn notif bahwa uang tidak cukup,
        //dan menggiring user untuk menginputkann kembali uang
        if (Uang < TotalBelanja)
        {
            Console.WriteLine("Uang anda tidak cukup, masukan jumlah yang sesuai dengan total belanja anda ");
            Console.ReadKey();
            goto InputUang;
        }
        //pengkondisian ketika uang yang dibayarkan lebih dari total belanja maka uang yang dibayarkan
        //dikurang total belanja dan disimpan di varibel kembalian
        else if (Uang > TotalBelanja)
        {
            Kembalian = Uang - TotalBelanja;
        }
        //pengkondisian ketika uang yang dibayarkan sama dengan total belanja, maka variabel kembalian bernilai 0
        else 
        {
            Kembalian = 0;
        }
        //fungsi Clear akan dieksekusi ketika sudah melakukan pembayaran dengan tujuan untuk membersihkan CMD
        //dan selanjutnya membuat Header tabel
        Console.Clear();
        Console.SetCursorPosition(0, 2); Console.Write("|---------------------------------------------------|");
        Console.SetCursorPosition(0, 3); Console.Write("|---------------- TOKO ATK ZAHRAN ------------------|");
        Console.SetCursorPosition(0,4);  Console.Write("|---------------------------------------------------|");
        Console.SetCursorPosition(0, 5); Console.Write("| No");
        Console.SetCursorPosition(5, 5); Console.Write("| Nama Barang");
        Console.SetCursorPosition(20, 5); Console.Write("| Harga Barang");
        Console.SetCursorPosition(36, 5); Console.Write("| Jumlah Barang |");
        Console.SetCursorPosition(0, 6); Console.Write("-----------------------------------------------------");
        //fungsi output dibawah ini dippanggil ketika proses pembayaran telah selesai, fungsi Output
        //mengirimkan argumen ke fungsi Ouput berupa
        //NamaBarang, HargaSatuan, JumlahBarang, IndexSekarang, TotalBelanja, Uang, Kembalian
        Output(NamaBarang, HargaSatuan, JumlahBarang, IndexSekarang, TotalBelanja, Uang, Kembalian);
    }
    //Fungsi Procedure dibawah ini Berfungsi untuk Menampilkan output dari data-data yang sudah di imput sebelum nya
    //yang mempunyai parameter string[] Nama_Barang, int[] Harga_Satuan, int[] Jumlah_Barang, int Index_Sekarang,
    //int Total_Belanja, int uang, int kembalian
    //data yang dioutput diantara nya nama barang, harga satu barang, jumlah barang yang dibeli, total belanjaan,
    //uang yang dibayarkan, dan kembalian. 
    static void Output(string[] Nama_Barang, int[] Harga_Satuan, int[] Jumlah_Barang, int Index_Sekarang, int Total_Belanja, int uang, int kembalian)
    {
        //Perulangan yang berfungsi untuk mengoutput barang apa saya yang telah dibeli
        for (int a = 0; a < Index_Sekarang; a++)
        {
            Console.SetCursorPosition(0, 7+a); Console.Write("|");
            Console.SetCursorPosition(2, 7 + a); Console.Write(a+1);
            Console.SetCursorPosition(5, 7 + a); Console.Write("|");
            Console.SetCursorPosition(7, 7+a); Console.Write(Nama_Barang[a]);
            Console.SetCursorPosition(20, 7 + a); Console.Write("|");
            Console.SetCursorPosition(25, 7 + a);  Console.Write(Harga_Satuan[a]);
            Console.SetCursorPosition(36, 7 + a); Console.Write("|");
            Console.SetCursorPosition(43, 7 + a);  Console.Write(Jumlah_Barang[a]);
            Console.SetCursorPosition(52, 7 + a); Console.Write("|");
        }
        //kode di bawah ini berfungsi untuk menampilkan totak belanja, uang yang dibayarkan, dan kembalian
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|Total Belanjaan anda sebesar             : " + Total_Belanja + "   |");
        Console.WriteLine("|Jumlah Uang yang anda bayar kan sebesar  : "+ uang + "   |");
        Console.WriteLine("|Kembalian anda sebesar                   : " +kembalian+ "    |");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|-----Terimakasih Sudah Berbelanja di Toko Kami-----|");
    }
}