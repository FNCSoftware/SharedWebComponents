namespace Consumer.Models {
    public class TestViewModel {
        public string AnotherGreeting { get; set; }

        public TestViewModel(string greeting, string anotherGreeting) {
            Shared = new SharedWebComponents.Models.TestViewModel(greeting);
            AnotherGreeting = anotherGreeting;
        }

        public SharedWebComponents.Models.TestViewModel Shared { get; set; }
    }
}