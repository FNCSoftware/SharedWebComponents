namespace SharedWebComponents.Models {
    public class TestViewModel {
        public TestViewModel(string greeting) {
            Greeting = greeting;
        }

        public string Greeting { get; set; }
    }
}