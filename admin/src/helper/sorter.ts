

export const compareNumber = (a: number, b: number) => {
    // Compare the dates and return the result
    if (a < b) {
      return -1;
    } else if (a > b) {
      return 1;
    } else {
      return 0;
    }
  };