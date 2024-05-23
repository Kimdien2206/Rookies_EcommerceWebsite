import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminPage from "./pages/AdminPage";
import Dashboard from "./component/Dashboard";
import LoginPage from "./pages/LoginPage";
import Product from "./component/Product";
import Category from "./component/Category";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route key={"login"} path="/" index element={<LoginPage />} />
        <Route key={"admin"} path="/admin" element={<AdminPage />}>
          <Route key={"dashboard"} path="dashboard" index element={<Dashboard />}/>
          <Route key={"product"} path="product" element={<Product />}/>
          <Route key={"category"} path="category" element={<Category />}/>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
