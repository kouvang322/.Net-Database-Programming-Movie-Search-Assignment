//using MovieLibraryAssignment;
//using System;
//using Xunit;

//namespace MovieLibraryAssignmnet.Tests
//{
//    public class CorrectNewMovieEntryServiceTest
//    {

//        private readonly ListItemService _ListItem;
        


//        public CorrectNewMovieEntryServiceTest()
//        {
//            _ListItem = new ListItemService();
//        }
        
//        [Fact]
//        public void Movie_String_Is_In_Correct_Format_Success()
//        {
//            var response = _ListItem.AddCorrectStringFormat(1, " Toy Story (1995)"," Adventure, Animation, Children, Comedy, Fantasy");

//            Assert.Equal("1, Toy Story (1995), Adventure, Animation, Children, Comedy, Fantasy", response);
//        }


        //This Test can not be tested because it requires the user to enter a key
        //[Fact]
        //public void Ensure_Either_Y_Or_N_Is_Pressed_Success()
        //{
        //    var response = _ListItem.ensureChoiceIsEitherYesOrNO();

        //    Assert.Equal("Y", response);
        //    Assert.Equal("N", response);

        //}

//    }
//}
