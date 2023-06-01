import { style } from "@vanilla-extract/css"
import { colors } from '../../colors.css'
import { theme } from "../../theme.css"
import { media } from "../ui.css"

export const dekstopHeader = style({
  display: "none",
  "@media": {
    [media.small]: {
      display: "block",
      padding: "4px 16px",
      margin: 0,
      backgroundColor: colors.darkBlue,
      minWidth: '100%',
      color: colors.white
    },
  }
})
