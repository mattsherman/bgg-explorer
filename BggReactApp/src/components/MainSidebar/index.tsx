import { NavLink } from 'react-router';

import classes from './index.module.css';

export function MainSidebar() {
  return (
    <nav className={classes['main-sidebar']}>
      <menu>
        <li className={classes['home-link']}>
          <NavLink to="/">BGG Explorer</NavLink>
        </li>
        <li className={classes['sub-menu']}>
          <header>Global Collections</header>
          <menu>
            <li>
              <NavLink to="/hot-items">Hot Items</NavLink>
            </li>
          </menu>
        </li>
        <li className={classes['sub-menu']}>
          <header>User Collections</header>
          <menu>
            <li>
              <NavLink to="/user/mattsherman/collection">JAM</NavLink>
            </li>
            <li>
              <NavLink to="/user/dccircuit/collection">Andy</NavLink>
            </li>
          </menu>
        </li>
      </menu>
    </nav>
  );
}
