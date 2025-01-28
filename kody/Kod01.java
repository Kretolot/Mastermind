// Online Java Compiler
// Use this editor to write, compile and run your Java code online
class Samochod{
    private String marka;
    private int rocznik;

    public Samochod(String marka, int rocznik){
        this.marka = marka;
        this.rocznik = rocznik;
    }

    public Samochod(Samochod innySamochod) {
        this.marka = innySamochod.marka;
        this.rocznik = innySamochod.rocznik;
    }

    public void show(){
        System.out.println("Marka: " + this.marka + " rocznik " + this.rocznik);
    }
}



public class Kod01 {
    public static void main(String[] args) {
        Samochod sam1 = new Samochod("BMW", 2024);
        Samochod sam2 = new Samochod("Audi", 2025);

        sam1.show();
        sam2.show();
    }
}