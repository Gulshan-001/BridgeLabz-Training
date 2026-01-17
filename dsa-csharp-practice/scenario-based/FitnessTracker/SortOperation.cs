class SortOperation
{
    public void Sort(Runners[] runners, int count)
    {
        bool swapped;

        for (int i = 0; i < count - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < count - i - 1; j++)
            {
                // higher distance first
                if (runners[j].DistanceRun < runners[j + 1].DistanceRun)
                {
                    Swap(runners, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    private void Swap(Runners[] runners, int i, int j)
    {
        Runners temp = runners[i];
        runners[i] = runners[j];
        runners[j] = temp;
    }
}
