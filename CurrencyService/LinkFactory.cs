public class LinkFactory {
    public static Link GetLink() {
        Link chain = new FirstLink();
        Link secondLink = new SecondLink();
        Link thirdLink = new ThirdLink();

        chain.SetSuccessor(secondLink);
        secondLink.SetSuccessor(thirdLink);
        return chain;
    }
}