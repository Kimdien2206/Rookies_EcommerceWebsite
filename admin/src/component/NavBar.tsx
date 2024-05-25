import { Image, Menu, MenuProps } from "antd";
import React from "react";
import DashboardIcon from "../assets/menu/dashboard-icon.png";
import OrderIcon from "../assets/menu/box_96px.png";
import ProductIcon from "../assets/menu/t-shirt_96px.png";
import InformationIcon from "../assets/menu/user_96px.png";
import DeliveryIcon from "../assets/menu/in_transit_96px.png";
import ReceiptIcon from "../assets/menu/receipt_96px.png";
import VoucherIcon from "../assets/icon/sale_96px.png";
import { useNavigate } from "react-router-dom";

const generateImageIcon = (path: string) => {
  return (
    <div className="centerflex">
      <Image src={path} width={25} height={25} preview={false} />
    </div>
  );
};


const menu: MenuProps["items"] = [
  {
    key: "dashboard",
    label: "Dashboard",
    icon: generateImageIcon(DashboardIcon),
  },
  {
    key: "order",
    label: "Order",
    icon: generateImageIcon(OrderIcon),
    children: [
      {
        key: "order/waiting",
        label: "Waiting",
      },
      {
        key: "order/completed",
        label: "Completed",
      },
      {
        key: "order/canceled",
        label: "Canceled",
      },
    ],
  },
  {
    key: "product",
    label: "Product",
    icon: generateImageIcon(ProductIcon),
    children: [
      {
        key: "category/",
        label: "Category",
      },
      {
        key: "product/",
        label: "Products",
      },
    ],
  },
  {
    key: "delivery",
    icon: generateImageIcon(DeliveryIcon),
    label: "Delivery",
  },
  {
    key: "invoice",
    label: "Invoice",
    icon: generateImageIcon(ReceiptIcon),
    children: [
      {
        key: "invoice/paid",
        label: "Paid",
      },
      {
        key: "invoice/unpaid",
        label: "Unpaid",
      },
    ],
  },
  // {
  //   key: 'feedback',
  //   label: 'Đánh giá',
  //   icon: generateImageIcon(ReivewIcon)
  // },
  {
    key: "voucher",
    label: "Voucher",
    icon: generateImageIcon(VoucherIcon),
  },
  {
    key: "customer-management",
    label: "Customer",
    icon: generateImageIcon(InformationIcon),
  },
];


const NavBar = () => {
  const nav = useNavigate();

  const onClickHandler: MenuProps["onClick"] = (e) => {
    if (e.key === "/login") {
      nav("/");
    } else {
      nav(e.key);
    }
  };
  return (
    <Menu
      theme="dark"
      mode="inline"
      defaultSelectedKeys={["1"]}
      items={menu}
      onClick={onClickHandler}
    />
  );
};

export default NavBar;
