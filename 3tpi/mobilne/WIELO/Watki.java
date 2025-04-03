package WIELO;

class mojeWatki extends Thread{

    private String nazwaWatku;

    public mojeWatki(String nazwa){
        this.nazwaWatku = nazwa;
    }

    
    @Override
    public void run(){
        for (int i = 0; i < 100; i++){
            System.out.println(nazwaWatku + " : " + i);
            try{
                Thread.sleep(1000);
            }
            catch (InterruptedException e){
                System.out.println("Blad: " + e);
            }
        }
        System.out.println(nazwaWatku + " zakonczony");
    }

}


//-------------------MAIN------------------


public class Watki{
    public static void main(String[] args) {

        mojeWatki watek1 = new mojeWatki("Watek 1");
        mojeWatki watek2 = new mojeWatki("Watek 2");
        mojeWatki watek3 = new mojeWatki("Watek 3");

        watek1.start();
        watek2.start();
        watek3.start();


    }
}