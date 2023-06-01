import * as React from "react"
import { graphql, useStaticQuery } from "gatsby"
import {
  Container,
  Flex,
  FlexList,
  Space,
  NavLink,
  Button,
} from "../ui"
import NavItemGroup from "../nav-item-group"
import { dekstopHeader } from './header.css'

export default function Header() {
  const data = useStaticQuery(graphql`
    query {
      layout {
        header {
          id
          navItems {
            id
            navItemType
            ... on NavItem {
              href
              text
            }
            ... on NavItemGroup {
              name
              navItems {
                id
                href
                text
                description
                icon {
                  alt
                  gatsbyImageData
                }
              }
            }
          }
          cta {
            id
            href
            text
          }
        }
      }
    }
  `)

  const { navItems, cta } = data.layout.header
  const [isOpen, setOpen] = React.useState(false)

  React.useEffect(() => {
    if (isOpen) {
      document.body.style.overflowY = "hidden"
    } else {
      document.body.style.overflowY = "visible"
    }
  }, [isOpen])

  return (
    <header>
      <Container className={dekstopHeader}>
        <Space size={2} />
        <Flex variant="spaceBetween">
          <nav>
            <FlexList gap={4}>
              {navItems &&
                navItems.map((navItem) => (
                  <li key={navItem.id}>
                    {navItem.navItemType === "Group" ? (
                      <NavItemGroup
                        name={navItem.name}
                        navItems={navItem.navItems}
                      />
                    ) : (
                      <NavLink to={navItem.href}>{navItem.text}</NavLink>
                    )}
                  </li>
                ))}
            </FlexList>
          </nav>
          <div>{cta && <Button to={cta.href}>{cta.text}</Button>}</div>
        </Flex>
      </Container>
    </header>
  )
}
