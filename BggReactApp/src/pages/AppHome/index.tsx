import { MainMenu } from '../../components/MainMenu';

import classes from './index.module.css';

export function AppHome() {
  return (
    <div className={classes['app-home']}>
      <div className={classes['main-menu-wrapper']}>
        <MainMenu />
      </div>
    </div>
  );
}
