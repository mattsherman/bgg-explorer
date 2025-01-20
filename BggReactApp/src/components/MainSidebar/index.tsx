import { NavLink } from 'react-router';

import { CollectionIcon } from '../icons/CollectionIcon';
import { DiceIcon } from '../icons/DiceIcon';

import classes from './index.module.css';

export function MainSidebar() {
  return (
    <nav className={classes['main-sidebar']}>
      <menu>
        <li className={classes['home-link']}>
          <NavLink to="/">
            <DiceIcon />
            BGG Explorer
          </NavLink>
        </li>
        <li className={classes['sub-menu']}>
          <header>Global Collections</header>
          <menu>
            <li>
              <NavLink to="/hot-items">
                <CollectionIcon />
                Hot Items
              </NavLink>
            </li>
          </menu>
        </li>
        <li className={classes['sub-menu']}>
          <header>User Collections</header>
          <menu>
            <li>
              <NavLink to="/user/mattsherman/collection">
                <CollectionIcon />
                JAM
              </NavLink>
            </li>
            <li>
              <NavLink to="/user/dccircuit/collection">
                <CollectionIcon />
                Andy
              </NavLink>
            </li>
          </menu>
        </li>
      </menu>
    </nav>
  );
}
