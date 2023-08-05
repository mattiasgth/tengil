import { Select, SelectProps } from "@mui/material";
import { useField, useFormikContext } from "formik";


type SelectFormikProps<T> = {
  name: string;
} & Omit<SelectProps<T>, "onChange" | "value">;


const SelectFormik = <T = unknown>(props: SelectFormikProps<T>) => {
  const { name, ...restProps } = props;
  const [field] = useField(name);
  const { setFieldValue } = useFormikContext();
  return (
    <Select
      {...restProps}
      value={field.value ?? null}
      onChange={(val) => setFieldValue(name, val.target.value) }
    />
  );
};
export default SelectFormik;