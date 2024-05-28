import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminPage from "./pages/AdminPage";
import Dashboard from "./component/Dashboard";
import LoginPage from "./pages/LoginPage";
import Products from "./component/Product";
import Category from "./component/Category";
import User from "./component/User";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route key={"login"} path="/" index element={<LoginPage />} />
        <Route key={"admin"} path="/admin" element={<AdminPage />}>
          <Route key={"dashboard"} path="dashboard" index element={<Dashboard />}/>
          <Route key={"product"} path="product" element={<Products />}/>
          <Route key={"category"} path="category" element={<Category />}/>
          <Route key={"user"} path="user" element={<User />}/>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
