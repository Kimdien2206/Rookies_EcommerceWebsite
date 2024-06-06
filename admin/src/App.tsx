import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminPage from "./pages/AdminPage";
import Dashboard from "./component/Dashboard";
import LoginPage from "./pages/LoginPage";
import Products from "./component/Product";
import Category from "./component/Category";
import User from "./component/User";
import NotFound from "./pages/error/NotFound";
import PaidInvoice from "./component/PaidInvoice";
import UnpaidInvoice from "./component/UnpaidInvoice";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route key={"login"} path="/" index element={<LoginPage />} />
          <Route key={"admin"} path="/admin" element={<AdminPage />}>
            <Route
              key={"dashboard"}
              path="dashboard"
              index
              element={<Dashboard />}
            />
            <Route key={"product"} path="product" element={<Products />} />
            <Route key={"category"} path="category" element={<Category />} />
            <Route key={"user"} path="user" element={<User />} />
            <Route key={"paid"} path="invoice/paid" element={<PaidInvoice />} />
            <Route
              key={"unpaid"}
              path="invoice/unpaid"
              element={<UnpaidInvoice />}
            />
          </Route>
        <Route key={"not-found"} path="*" element={<NotFound />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
