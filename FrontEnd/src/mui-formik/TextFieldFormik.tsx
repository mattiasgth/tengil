import { TextField, TextFieldProps, TextFieldVariants } from "@mui/material";
import { useField, useFormikContext } from "formik";


type TextFieldFormikProps = {
  name: string;
} & Omit<TextFieldProps, "onChange" | "value">;


const TextFieldFormik = (props: TextFieldFormikProps) => {
  const { name, ...restProps } = props;
  const [field] = useField(name);
  const { setFieldValue } = useFormikContext();
  return (
    <TextField
      {...restProps}
      value={field.value ?? null}
      onChange={(val) => setFieldValue(name, val.target.value) }
    />
  );
};
export default TextFieldFormik;
