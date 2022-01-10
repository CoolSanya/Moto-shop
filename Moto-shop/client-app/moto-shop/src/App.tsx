import './App.css';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import DefaultLayout from "./components/containers/defaultLayout";
import LoginPage from "./components/auth/Login";
import RegisterPage from "./components/auth/Register";

import { ToastContainer, toast } from "react-toastify";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<DefaultLayout />}>
                    {/* <Route index element={<HomePage />} /> */}

                    <Route path="login" element={<LoginPage />} />
                    <Route path="register" element={<RegisterPage />} />

                    {/* <Route path="products" element={<Products />} />
                    <Route path="products/add" element={<AddProduct />} />
                    <Route path="products/edit" element={<EditProduct />} />
                    <Route path="*" element={<NoMatch />} /> */}
                </Route>
            </Routes>
            <ToastContainer pauseOnHover={false} pauseOnFocusLoss={false} />
        </Router>
    );
}

export default App;
