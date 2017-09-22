# LadySnake
Course Project for 526.

Related Link: [Learn Git](https://www.atlassian.com/git/tutorials/syncing)

---

### Standard for coding

> Make sure Git command can be executed in your terminal.

#### Steps to set up your local LadySnake:

- Open Terminal, go to the path you would like to store this project use `cd` command;
- Do `git clone https://github.com/yinghuihao/LadySnake.git`, this will clone the project from Github to your local machine;
- Go into the /LadySnake folder, check your branch is on *master*: `git branch`.

> Branch is like different version of the code. We normally use *master* branch as the major and no-bug version code. And *devel-qa* as the testing and quality assurance branch for team leader/code reviewer to merge code from different members and do the test.

For different team member, you should have your own branch:

| Member  | Branch |
|---------|--------|
| Yinghui Hao | [haoyinghui](https://github.com/yinghuihao/LadySnake/tree/haoyinghui)|

#### Steps to set up your own Branch:

- In the /LadySnake folder, do `git checkout -b <your new branch name> <from branch name>` to create your own local new branch (For here, <from branch name> can be *master*).
- Then do `git push origin <your new branch name>` to push your branch to Github. And now you should be able to work on your own branch. You can check your current branch is <your new branch name> with `git branch`.

#### Standard of coding every week:

- Before every week's task, do `git pull` to sync your local folder with remote Github;
- Then do `git merge master` to sync your own branch with the lateset all-merged, no-bug version of project. If there are any merge conflicts;

