# JobAdderAPI

## Build and Run instructions
1. Build solution
2. Run Unit tests to make sure solution works as expected
3. Run solution

# Assumptions

**Note :** Since Skills listed in order from strongest to weakest, each skill has assighed with weight and It will be the base for logic to calculate best candidate for a given job.

1. Order of Skill tags in Job and Skills in candidate has equal Priority. Ex : if Weight given to 1st skill in Job is 100 1st skill in candidate should have 100.
2. Skill Tags in Jobs does not have duplicates, if there is any only first 1 will take into calculation
3. Skill Tags in Candidate does not have duplicates, if there is any only first 1 will take into calculation
4. Since Candidate matching logic based on Priority based multiplication there may be more than 1 candidates with Highest score. But since test only require 1 candidate API will return only 1, however retrun list just to show there can be multiple.
5. Assume Candidates are Adding and Removing frequently.


