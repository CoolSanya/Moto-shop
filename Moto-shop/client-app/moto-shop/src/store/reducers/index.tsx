import { combineReducers } from "redux";
import { authReducer } from "../../components/auth/Login/reducer";
//import {productReducer} from "../../components/products/reducer"

export const rootReducer = combineReducers({
    auth: authReducer,
    //product: productReducer,
});

export type RootState = ReturnType<typeof rootReducer>;