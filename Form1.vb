Public Class Form1
    Dim ders_kodu(), ders_adi(), ders_akts(), ders_kredi(), ders_saati(), ders_hocasi() As String
    Dim sayi1, sayi2, sayi3 As Integer

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ListView2.SelectedItems.Count = 0 Then
            MsgBox("Silmek İstediğiniz Öğrencileri Seçiniz")
        Else
            For i As Integer = ListView2.SelectedItems.Count - 1 To 0 Step -1
                ListView2.Items.Remove(ListView2.SelectedItems(i))
            Next
            MsgBox("Silindi")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        System.Diagnostics.Process.Start(TextBox4.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("Kayıt Sayısı : " + ListView2.Items.Count.ToString())
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim veri As New ListViewItem
        veri = New ListViewItem(InputBox("Okul No Giriniz"))
        veri.SubItems.Add(InputBox("Ad Giriniz"))
        veri.SubItems.Add(InputBox("Soyad Giriniz"))
        veri.SubItems.Add(InputBox("TC No Giriniz"))
        veri.SubItems.Add(InputBox("Sınıf Giriniz"))
        veri.SubItems.Add(InputBox("Kayıt Yılı Giriniz"))
        ListView2.Items.Add(veri)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rnd As New Random
        Dim tek As Boolean = False
        Do While (tek = False)
            sayi1 = rnd.Next(1, 5)
            If sayi1 Mod 2 = 1 Then
                tek = True
            End If
        Loop
        tek = False
        Do While (tek = False)
            sayi2 = rnd.Next(1, 5)
            If sayi2 Mod 2 = 1 Then
                tek = True
            End If
        Loop
        tek = False
        Do While (tek = False)
            sayi3 = rnd.Next(1, 5)
            If sayi3 Mod 2 = 1 Then
                tek = True
            End If
        Loop
        VScrollBar1.Value = sayi1
        VScrollBar2.Value = sayi2
        VScrollBar3.Value = sayi3
        TextBox1.Text = sayi1.ToString()
        TextBox2.Text = sayi2.ToString()
        TextBox3.Text = sayi3.ToString()
        If sayi1 = sayi2 And sayi1 = sayi3 Then
            Label1.Text = "Tebrikler. Telefon Kazandınız"
            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\kazandin.jpg")
            PictureBox1.Width = 150
            PictureBox1.Height = 150
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox1.Width = 0
            PictureBox1.Height = 0
            Label1.Text = "Tekrar Deneyin"
        End If
    End Sub

    Dim sayac As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView2.Sorting = SortOrder.Ascending
        ListView2.View = View.Details
        ListView2.FullRowSelect = True
        ListView2.GridLines = True
        ListView2.Columns.Add("Okul No", 100)
        ListView2.Columns.Add("Ad", 100)
        ListView2.Columns.Add("Soyad", 100)
        ListView2.Columns.Add("TC No", 100)
        ListView2.Columns.Add("Sınıf", 100)
        ListView2.Columns.Add("Kayıt Yılı", 100)

        Label1.Text = "Tekrar Deneyin"

        VScrollBar1.Minimum = 1
        VScrollBar2.Minimum = 1
        VScrollBar3.Minimum = 1
        VScrollBar1.Maximum = 100
        VScrollBar2.Maximum = 100
        VScrollBar3.Maximum = 100

        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Columns.Add("Ders Kodu", 100)
        ListView1.Columns.Add("Ders Adı", 100)
        ListView1.Columns.Add("Ders AKTS", 100)
        ListView1.Columns.Add("Ders Kredi", 100)
        ListView1.Columns.Add("Ders Saati", 100)
        ListView1.Columns.Add("Ders Hocası", 100)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sayac += 1
        Dim ders_ad As String = InputBox("Eklemek İstediğiniz Dersin Adını Giriniz")
        If CheckedListBox1.Items.Contains(ders_ad) Then
            MsgBox("Kayıtlı Ders Girişi Yaptınız")
        Else
            CheckedListBox1.Items.Add(ders_ad)
            ReDim Preserve ders_kodu(sayac - 1)
            ders_kodu(sayac - 1) = InputBox("Dersin Kodu")
            ReDim Preserve ders_adi(sayac - 1)
            ders_adi(sayac - 1) = ders_ad
            ReDim Preserve ders_akts(sayac - 1)
            ders_akts(sayac - 1) = InputBox("Dersin AKTS'si")
            ReDim Preserve ders_kredi(sayac - 1)
            ders_kredi(sayac - 1) = InputBox("Dersin Kredisi")
            ReDim Preserve ders_saati(sayac - 1)
            ders_saati(sayac - 1) = InputBox("Haftalık Ders Saati")
            ReDim Preserve ders_hocasi(sayac - 1)
            ders_hocasi(sayac - 1) = InputBox("Dersin Hocası")
            MsgBox("Kayıt Başarılı")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckedListBox1.CheckedItems.Count = 0 Then
            MsgBox("Seçim Yapmadınız")
        Else
            For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
                Dim x, y, z As Integer
                Dim bul As Boolean = False
                Do While (bul = False)
                    For y = 0 To ders_adi.Length - 1
                        If CheckedListBox1.CheckedItems(i).Equals(ders_adi(y)) Then
                            z = y
                            bul = True
                        End If
                    Next
                Loop
                Dim veri As ListViewItem = New ListViewItem()
                veri = New ListViewItem(ders_kodu(z))
                veri.SubItems.Add(ders_adi(z))
                veri.SubItems.Add(ders_akts(z))
                veri.SubItems.Add(ders_kredi(z))
                veri.SubItems.Add(ders_saati(z))
                veri.SubItems.Add(ders_hocasi(z))
                ListView1.Items.Add(veri)
            Next
            MsgBox("İşlem Başarılı")
        End If
    End Sub
End Class
