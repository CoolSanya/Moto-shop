//import * as CarActionCreators from "../../components/CarsList/car-actions";
import * as AuthActionCreators from "../../components/auth/Login/action";
import * as RegActionCreators from "../../components/auth/Register/action";

const actions = {
  //...CarActionCreators,
  ...AuthActionCreators,
  ...RegActionCreators,
  // ...SendingCarActionCreators,
  // ...CartActionCreators,
  // ...ProfileActionCreators,
  // ...UsersActionCreators,
  // ...FleshMessagesActionCreator,
  // ...RecoverPasswordActionCreator,
  // ...PaginateActionCreator,
  // ...CategoryActionCreators,
};
 
export default  actions;
