/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import { DatePicker, Form, Input, InputNumber, Select } from "antd";
import { Rule } from "antd/es/form";
import TextArea from "antd/es/input/TextArea";
import { locale } from "dayjs";

interface EditableCellProps extends React.HTMLAttributes<HTMLElement> {
  editing: boolean;
  dataIndex: string;
  title: any;
  inputType: string;
  record: any;
  index: number;
  children: React.ReactNode;
  rules: Rule[];
  tooltip: string;
  initData: any;
}


const EditableCell: React.FC<EditableCellProps> = ({
  editing,
  dataIndex,
  title,
  inputType,
  record,
  index,
  children,
  rules = [],
  tooltip = '',
  ...restProps
}) => {
  return (
    <td {...restProps}>
      {editing ? (
        <Form.Item
          name={dataIndex}
          style={{ margin: 0 }}
          rules={rules}
          tooltip={tooltip}
        >
          <Input />
        </Form.Item>
      ) : (
        children
      )}
    </td>
  );
};

export default EditableCell;